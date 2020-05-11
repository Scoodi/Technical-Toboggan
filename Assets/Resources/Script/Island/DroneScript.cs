using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneScript : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;
    [SerializeField] private float zOffset;
    [SerializeField] private float orbitSpeed;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(player.transform.position.x + xOffset,
            player.transform.position.y + yOffset,
            player.transform.position.z + zOffset);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(player.transform.position, Vector3.up, orbitSpeed * Time.deltaTime);
        this.transform.LookAt(player.transform.position);
    }
}
