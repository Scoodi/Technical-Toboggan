using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardScript : MonoBehaviour
{
    public string hazardType;

    //Idea is to take hazard type, and then create a function for it, and use combination of "Constructor" effects to form a full effect. I.E, Alter direction then speed to do directional boost.
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Flipper (GameObject player)
    {
        
    }

    void AddVelocity (GameObject player, Vector3 direction, float force)
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.AddForce(direction * force);
    }

    IEnumerator AlterSpeed(GameObject player, float change, float time)
    {
        TankScript playerScript = player.GetComponent<TankScript>();
        playerScript.speed += change;
        yield return new WaitForSeconds(time);
        playerScript.speed -= change;
    }

    void AlterDirection(GameObject player, Vector3 direction)
    {
        player.transform.rotation = Quaternion.LookRotation(direction,Vector3.up);
    }

    void RemoveControl(GameObject player)
    {
        //todo add input layer to disable
    }

    void SpawnObject(GameObject player, GameObject prefabToSpawn)
    {
        Instantiate(prefabToSpawn, player.transform.position, player.transform.rotation, player.transform);
    }
}
