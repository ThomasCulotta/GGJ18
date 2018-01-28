using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationDevice : MonoBehaviour {

    private const float deviceRadius = 10f;
    private const int radioLayerMask = 1 << 8;

	// Use this for initialization
	void Start () {
        GetRadioComponentColliders(transform.position, deviceRadius);
    }
	
	// Update is called once per frame
	void Update () {
        GetRadioComponentColliders(transform.position, deviceRadius);
	}

    // Params: Device postion and detection field radius
    // This function collects a list of collider
    void GetRadioComponentColliders(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius, radioLayerMask);
        int i = 0;
        if (i < hitColliders.Length)
        {
           Transform radioComponentTrans = hitColliders[i].transform;
           Debug.DrawLine(transform.position, radioComponentTrans.position, Color.red);
        }
    }
}
