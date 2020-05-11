using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingZone : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    [SerializeField] private Transform island;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.parent = island;
    }


    private void OnTriggerExit(Collider other)
    {
        if (rb = other.gameObject.GetComponent<Rigidbody>())
        {
            rb.freezeRotation = false;
        }      
    }
}
