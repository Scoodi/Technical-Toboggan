using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public int playerNumber = 0;
    public Transform shootPoint;
    public GameObject projectile;
    public float speed = 1f;
    public float shootSpeed = 1f;

    private bool onCooldown = false;
     private string xAccessName;
    private string yAccessName;

    // Start is called before the first frame update
    void Start()
    {
        xAccessName = "X" + playerNumber;
        yAccessName = "Y" + playerNumber;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInput();
    }

    void CheckForInput()
    {
        if (Input.GetButtonDown(xAccessName))
        {
            if (!onCooldown)
            {
                Instantiate(projectile, shootPoint.position, shootPoint.rotation);
                StartCoroutine(ShootCooldown());
            }
        }
        if (Input.GetButtonDown(yAccessName))
        {
            gameObject.GetComponentInChildren<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }

    IEnumerator ShootCooldown ()
    {
        onCooldown = true;
        gameObject.GetComponentInChildren<Renderer>().material.color = new Color(1,0,0);
        yield return new WaitForSeconds(shootSpeed);
        onCooldown = false;
        gameObject.GetComponentInChildren<Renderer>().material.color = new Color(0, 1, 0);
    }
}
