//===================== Team Snowflake ========================================
//
// Purpose: Pick Up (and Destroy) Object
//
//=============================================================================

using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    //-------------------------------------------------------------------------
    [RequireComponent(typeof(Interactable))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(VelocityEstimator))]
    public class PickUpItem : MonoBehaviour
    {
        public TrackInventory inventory;

        private VelocityEstimator velocityEstimator;

        //-------------------------------------------------
        void Awake()
        {
            velocityEstimator = GetComponent<VelocityEstimator>();

            Rigidbody rb = GetComponent<Rigidbody>();
            rb.maxAngularVelocity = 50.0f;
        }

        //-------------------------------------------------
        private void HandHoverUpdate(Hand hand)
        {
            //Trigger got pressed
            if (hand.GetStandardInteractionButtonDown())
            {
                hand.AttachObject(gameObject);
                ControllerButtonHints.HideButtonHint(hand, Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);
            }
        }

        //-------------------------------------------------
        private void OnAttachedToHand(Hand hand)
        {
            hand.HoverLock(null);

            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.interpolation = RigidbodyInterpolation.None;

            if (hand.controller == null)
            {
                velocityEstimator.BeginEstimatingVelocity();
            }

            hand.DetachObject(gameObject, false);
            hand.HoverUnlock(null);

            rb.gameObject.SetActive(false);

            inventory.UpdateItemList();            
        }
    }
}
