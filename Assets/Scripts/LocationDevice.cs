using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationDevice : MonoBehaviour {

    public GameObject waypoint;
    public Transform ScannerTransform;

    private const float deviceRadius = 10f;
    private const int radioLayerMask = 1 << 8;
	
    // Params: Device postion and detection field radius
    // This function collects a list of collider
    public void GetRadioComponentColliders()
    {
        Debug.Log("Set Waypoint");
        Collider[] hitColliders = Physics.OverlapSphere(ScannerTransform.position, deviceRadius, radioLayerMask);
        for (int i = 0; i< hitColliders.Length; i++)
        {
           Transform radioComponentTrans = hitColliders[i].transform;
           Instantiate(waypoint, radioComponentTrans.position, Quaternion.identity);
        }
    }
}
