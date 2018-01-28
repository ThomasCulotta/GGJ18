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

        //-------------------------------------------------
        void Awake()
        {
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

            // Drop/Detach from item and remove it
            hand.DetachObject(gameObject, false);
            hand.HoverUnlock(null);
            rb.gameObject.SetActive(false);

            // Update Inventory
            inventory.UpdateItemList();            
        }
    }
}
