using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneRotation : MonoBehaviour
{
    public Transform[] zonePositions;
    public GameObject zonePrefab;
    private GameObject zone;

    [SerializeField] private float rotateTime = 20;
    private float timeElapsed;
    private int currentZoneIndex;

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0.0f;

        //Create the zone and set the start position
        if (zonePositions.Length != 0)
            zone = Instantiate(zonePrefab, zonePositions[0].position, zonePositions[0].rotation);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        //When the zone has been active for the time of the zone rotation, increase the zone index
        if (timeElapsed > rotateTime)
        {
            timeElapsed = 0;

            //Increase the zone index and wrap to first zone if needed
            currentZoneIndex = (currentZoneIndex + 1) % zonePositions.Length;
            zone.transform.position = zonePositions[currentZoneIndex].position;      
        }
    }
}
