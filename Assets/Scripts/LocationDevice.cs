using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationDevice : MonoBehaviour {

    public GameObject waypoint;

    private const float deviceRadius = 10f;
    private const int radioLayerMask = 1 << 8;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            GetRadioComponentColliders(transform.position, deviceRadius);
        }
	}

    // Params: Device postion and detection field radius
    // This function collects a list of collider
    void GetRadioComponentColliders(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius, radioLayerMask);
        for (int i = 0; i< hitColliders.Length; i++)
        {
           Transform radioComponentTrans = hitColliders[i].transform;
           Instantiate(waypoint, radioComponentTrans.position, Quaternion.identity);
        }
    }
}
