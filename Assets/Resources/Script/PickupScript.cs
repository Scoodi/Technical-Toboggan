using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public Pickup[] pickups;

    private string type;
    private GameObject effectObject;
    private GameObject modelPrefab;
    private int projectileIndex;

    // Start is called before the first frame update
    void Start()
    {
        SetPickup(Random.Range(0,5));
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
        projectileIndex = pickups[pickupIndex].projectileIndex;

        Instantiate(pickups[pickupIndex].pickupPrefab, transform.position, Quaternion.identity, transform);
        gameObject.name = "Pickup (" + type + ")";
    }

    private void OnTriggerEnter(Collider collider)
    {
        TankScript tank = collider.gameObject.GetComponent<TankScript>();
        if (tank != null)
        {
            tank.ChangePowerup(type, projectileIndex);
            Destroy(gameObject);
        }
    }
}
