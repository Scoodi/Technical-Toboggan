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


    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float health = 100f;
    [SerializeField] private float respawnTime;
    private float verticalMove;
    private float horizontalMove;

    private Rigidbody rb;
    private bool onGround = true;

    MeshRenderer[] meshes;

    public enum EDirection 
    { 
        eLeft, eRight
    }
    

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

        //Get all the mesh renderers in the tank model 
        meshes = gameObject.GetComponentsInChildren<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {      
        CheckForInput();
    }

    void FixedUpdate()
    {
        Move();
    }


    public void Move()
    {
        //if no input then no need to move 
        if (Input.GetAxis(verticalAccessName).Equals(0) && Input.GetAxis(horizontalAccessName).Equals(0) || !onGround)
            return;
                  
        Vector3 movement = transform.right * Input.GetAxis(horizontalAccessName) + transform.forward * Input.GetAxis(verticalAccessName);

        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }

    void CheckForInput()
    {        
        if (Input.GetButton(aAccessName))
        {
            Turn(EDirection.eLeft);
        }
        if (Input.GetButton(bAccessName))
        {
            Turn(EDirection.eRight);
        }
    }
    
    public void Turn(EDirection argDirection)
    {
        if (argDirection == EDirection.eLeft)
        {
            transform.Rotate(Vector3.down * turnSpeed);
        }
        else if(argDirection == EDirection.eRight)
        {
            transform.Rotate(Vector3.up * turnSpeed);
        }
    }

    public void ChangeHealth (float hp)
    {
        health += hp;
        if (health <= 0f)
        {
            Die();
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }

    IEnumerator Respawn ()
    {

        /* Once we get a player and game manager we can move this stuff to over
         and make the code cleaner*/

        //Disable all the render meshes in the tank
        foreach (MeshRenderer mr in meshes)
        {
            mr.enabled = false;
        }

        rb.detectCollisions = false;
        rb.useGravity = false;

        yield return new WaitForSeconds(respawnTime);

        //Move the tank to its spawn point and reset its health 
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.rotation = spawnPoint.transform.rotation;
        transform.position = spawnPoint.transform.position;
        health = 100f;
         
        //Enable all the meshes 
        foreach (MeshRenderer mr in meshes)
        {
            mr.enabled = true;
        }

        rb.detectCollisions = true;
        rb.useGravity = true;
    }

    void Die ()
    {
        //TODO - Create a better affect for the tank dying, explosion 
        Debug.Log("Player " + playerNumber + " is dead");    
        StartCoroutine(Respawn());
    }


}
