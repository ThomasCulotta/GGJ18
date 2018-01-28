using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationDevice : MonoBehaviour {

    public int CooldownSeconds = 20;
    public GameObject waypoint;
    public Transform ScannerTransform;

    public bool CanPing => _canPing;

    public float deviceRadius = 100f;
    private const int radioLayerMask = 1 << 8;

    private bool _canPing;

    private void Awake()
    {
        _canPing = true;
    }

    // Params: Device postion and detection field radius
    // This function collects a list of collider
    public void GetRadioComponentColliders()
    {
        Debug.Log("Set Waypoint");
        Collider[] hitColliders = Physics.OverlapSphere(ScannerTransform.position, deviceRadius, radioLayerMask);
        for (int i = 0; i< hitColliders.Length; i++)
        {
           Transform radioComponentTrans = hitColliders[i].transform;
            float dist = Vector3.Distance(radioComponentTrans.position, transform.position);
           StartCoroutine(WaitForPulse(dist, radioComponentTrans.position));
        }

        if (hitColliders.Length > 0)
        {
            StartCoroutine(Cooldown());
        }
    }

    private IEnumerator WaitForPulse(float dist, Vector3 pos)
    {
        Debug.Log(dist);
        yield return new WaitForSeconds(dist / 50f);
        Instantiate(waypoint, pos, Quaternion.identity);
    }

    private IEnumerator Cooldown()
    {
        _canPing = false;
        yield return new WaitForSeconds(CooldownSeconds);
        _canPing = true;
    }
}
