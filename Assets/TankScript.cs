using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankScript : MonoBehaviour
{
    public int playerNumber = 0;
    public float speed = 10f;
    public float turnSpeed = 180f;

    private float movementInput;
    private float turnInput;
    private string verticalAccessName;
    private string horizontalAccessName;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Set Input Axes
        verticalAccessName = "Vertical" + playerNumber;
        horizontalAccessName = "Horizontal" + playerNumber;
        if (playerNumber == 0)
        {
            Debug.LogError("playerNumber not initialised");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInput();
        movementInput = Input.GetAxis(verticalAccessName);
        turnInput = Input.GetAxis(horizontalAccessName);
    }

    void FixedUpdate()
    {
        Move();
        Turn();
    }

    public void CheckForInput ()
    {

    }

    public void Move()
    {
        Vector3 movement = transform.forward * movementInput * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    public void Turn()
    {
        float turn = turnInput * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
