using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankScript : MonoBehaviour
{
    public int playerNumber = 0;

    //Speeds
    public float speed = 10f;
    public float turnSpeed = 2f;

    //Button inputs
    private string verticalAccessName;
    private string horizontalAccessName;
    private string aAccessName;
    private string bAccessName;


    private float verticalMove;
    private float horizontalMove;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Set Input Axes
        verticalAccessName = "Vertical" + playerNumber;
        horizontalAccessName = "Horizontal" + playerNumber;
        aAccessName = "A" + playerNumber;
        bAccessName = "B" + playerNumber;
        if (playerNumber == 0)
        {
            Debug.LogError("playerNumber not initialised");
        }
    }

    // Update is called once per frame
    void Update()
    {
        verticalMove = Input.GetAxis(verticalAccessName);
        horizontalMove = Input.GetAxis(horizontalAccessName);

        CheckForInput();

    }

    void FixedUpdate()
    {
        Move();
    }


    public void Move()
    {
        Vector3 movement = transform.right * horizontalMove + transform.forward * verticalMove;

        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }

    void CheckForInput()
    {
        if (Input.GetButton(aAccessName))
        {
            Turn(false);
        }
        if (Input.GetButton(bAccessName))
        {
            Turn(true);
        }
    }


    public void Turn(bool right)
    {
        if (!right)
        {
            transform.Rotate(Vector3.down * turnSpeed);
        }
        if (right)
        {
            transform.Rotate(Vector3.up * turnSpeed);
        }
    }
}
