using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrigger : MonoBehaviour
{

    TankScript player;

    private void OnTriggerEnter(Collider other)
    {
        if (player = other.GetComponent<TankScript>())
        {
            player.Die();
        }
    }
}
