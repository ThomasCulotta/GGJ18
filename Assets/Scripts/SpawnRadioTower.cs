using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRadioTower : MonoBehaviour {

    public TrackInventory inventory;
    //private Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        //rb = GetComponent<Rigidbody>();

        transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
        //if (Array.IndexOf(inventory.itemList, false) == -1)
        //{
        //    //GameObject.Instantiate()
        //    //rb = GetComponent<Rigidbody>();
        //    rb.gameObject.SetActive(true);
        //}
    }

    public void SpawnTower()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
