﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public Pickup[] pickups;

    private string type;
    private GameObject effectObject;
    private GameObject modelPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SetPickup(4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPickup(int pickupIndex)
    {
        //Sets internal variables to those from the array
        type = pickups[pickupIndex].name;
        effectObject = pickups[pickupIndex].effectObject;

        Instantiate(pickups[pickupIndex].pickupPrefab, transform.position, Quaternion.identity, transform);
        gameObject.name = "Pickup (" + type + ")";
    }

    private void OnCollisionEnter(Collision collision)
    {
        TankScript tank = collision.gameObject.GetComponent<TankScript>();
        if (tank != null)
        {
            Instantiate(effectObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
