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

    public Transform spawnPoint;
    [SerializeField] private float health = 100f;
    [SerializeField] private float respawnTime = 1;
    private float verticalMove;
    private float horizontalMove;

    private string currentPowerup = "None";
    private HUDScript hudController;
    private Rigidbody rb;
    private ShootScript shootController;
    private bool onGround = true;
    public bool isDead = false;

    public int score;

    SkinnedMeshRenderer[] meshes;

    // Start is called before the first frame update
    void Start()
    {
        //Get/Set HUDController
        hudController = (HUDScript)FindObjectOfType(typeof(HUDScript));
        RequestHUDUpdate();

        shootController = GetComponentInChildren<ShootScript>();
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
        meshes = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();

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
        transform.position = transform.position + movement * speed * Time.deltaTime;

        //rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }

    void CheckForInput()
    {        
        if (Input.GetButton(aAccessName))
        {
            transform.Rotate(Vector3.down * turnSpeed);
        }
        if (Input.GetButton(bAccessName))
        {
            transform.Rotate(Vector3.up * turnSpeed);
        }
    }
    
    public void ChangeHealth (float hp)
    {
        health += hp;
        RequestHUDUpdate();
        if (health <= 0f)
        {
            Die();
        }
    }

    public void ChangePowerup(string powerup, int projectileIndex)
    {
        currentPowerup = powerup;
        shootController.currentProjectile = projectileIndex;
        RequestHUDUpdate();
    }
    //Ground Detection
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
    void OnCollisionExit(Collision collision)
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
        foreach (SkinnedMeshRenderer mr in meshes)
        {
            mr.enabled = false;
        }

        //Deactivate the rigid body
        rb.detectCollisions = false;
        rb.isKinematic = true;

        yield return new WaitForSeconds(respawnTime);

        //Reset the rigid body
        rb.detectCollisions = true;
        rb.isKinematic = false;

        //Move the tank to its spawn point, reset health/powerup, and update UI
        transform.rotation = spawnPoint.transform.rotation;
        transform.position = spawnPoint.transform.position;
        health = 100f;
        currentPowerup = "None";
        RequestHUDUpdate();    
      
        //Enable all the meshes 
        foreach (SkinnedMeshRenderer mr in meshes)
        {
            mr.enabled = true;
        }
        isDead = false;
    }

    public void Die ()
    {
        //Give the other player points
        ScoreManager.instance.GivePlayerScoreForKill(playerNumber);

        isDead = true;

        //TODO - Create a better affect for the tank dying, explosion 
        Debug.Log("Player " + playerNumber + " is dead");    
        StartCoroutine(Respawn());
    }

    public void RequestHUDUpdate ()
    {
        hudController.UpdateHUD(playerNumber, health, currentPowerup, score);
    }


}
