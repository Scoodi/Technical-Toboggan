//using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private GameObject destinationJumpPad;
    [SerializeField] private Vector3 halfwayPoint;
    [SerializeField] private float jumpHeightOffset;
    [SerializeField] private float jumpTimer = 0f;
    [SerializeField] private float jumpDuration;
    
    private GameObject player;
    private Rigidbody playerRigidBody;
    bool isJumping = false;

    private Vector3 Bezier(float t, Vector3 p0, Vector3 p1, Vector3 p2) //this could also be done by calculating velocity laterally and horizontally, due to our ground checks dont think this is necessary
    {
        float timeDiff = 1 - t;
        float timeSq = t * t;
        float timeDiffSq = timeDiff * timeDiff;
        Vector3 point = timeDiffSq * p0 + 2 * timeDiff * t * p1 + timeSq * p2;
        return point;
    }

    private void calcVelocity()
    {
        //    Vector3 pos = this.transform.position;
        //    Vector3 target = destinationJumpPad.transform.position;

        //    player.transform.LookAt(new Vector3(destinationJumpPad.transform.position.x, this.transform.position.y, destinationJumpPad.transform.position.z));

        //    float _angle = Vector3.Angle(target, pos);

        //    Vector3 projectileXZPos = new Vector3(this.transform.position.x, 0.0f, this.transform.position.z);
        //    Vector3 targetXZPos = new Vector3(destinationJumpPad.transform.position.x, 0.0f, destinationJumpPad.transform.position.z);

        //    float R = Vector3.Distance(projectileXZPos, targetXZPos);
        //    float G = Physics.gravity.y;
        //    float alpha = _angle * Mathf.Deg2Rad; // in radians
        //    float H = destinationJumpPad.transform.position.y - this.transform.position.y;

        //    float tanAlpha = Mathf.Tan(alpha);
        //    float Vz = Mathf.Sqrt(G * R * R / (2.0f * (H - R * tanAlpha)));
        //    float Vy = tanAlpha * Vz;

        //    // create the velocity vector in local space
        //    Vector3 localVelocity = new Vector3(0f, Vy, Vz);

        //    // transform it to global vector
        //    Vector3 globalVelocity = this.transform.TransformDirection(localVelocity);

        //    // launch the cube by setting its initial velocity
        //    player.GetComponent<Rigidbody>().velocity = globalVelocity;


        halfwayPoint = (this.transform.position + destinationJumpPad.transform.position) / 2;

        if (this.transform.position.y > destinationJumpPad.transform.position.y)
        {
            halfwayPoint.y = this.transform.position.y + jumpHeightOffset;
        }
        else
        {
            halfwayPoint.y = destinationJumpPad.transform.position.y + jumpHeightOffset;
        }      
    }

    // Start is called before the first frame update
    void Start()
    {
        //halfwayPoint = (this.transform.position + destinationJumpPad.transform.position) / 2;

        //if (this.transform.position.y > destinationJumpPad.transform.position.y)
        //{
        //    halfwayPoint.y = this.transform.position.y + jumpHeightOffset;
        //} else
        //{
        //    halfwayPoint.y = destinationJumpPad.transform.position.y + jumpHeightOffset;
        //}

        jumpDuration *= Time.deltaTime;
        jumpTimer += jumpDuration;
    }

    private void Update()
    {
        if (isJumping)
        {
            if (jumpTimer >= 0.99f)
            {
                //Jump is finished
                playerRigidBody.angularVelocity = Vector3.zero;
                playerRigidBody.velocity = Vector3.zero;
                isJumping = false;
            }
            jumpTimer += jumpDuration;
            player.transform.position = Bezier(jumpTimer, this.transform.position, halfwayPoint, destinationJumpPad.transform.position);
        }
        else jumpTimer = 0;
    }

    private void OnTriggerEnter(Collider other)
    {    
        if (playerRigidBody = other.GetComponent<Rigidbody>())
        {
            player = other.gameObject;
            playerRigidBody.freezeRotation = true;
            calcVelocity();
            isJumping = true;
        }      
    }
}
