using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandFloating : MonoBehaviour
{
    private enum eState { WOBBLE = 0, TRANSITION };

    [SerializeField] private float pos0 = 5.0f;
    [SerializeField] private float pos1 = -5.0f;
    [SerializeField] private Vector3 randPos;
    [SerializeField] private float wobbleSpeed = 2f; //speed of the wobble phase
    [SerializeField] private float stateTransition = 15.0f; //time between wobble and transition
    [SerializeField] private eState state = eState.TRANSITION;
    [SerializeField] private float wobbleTimer; //how long spent in wobble phase
    [SerializeField] private float wobbleHeightDivisor = 2f; //what to divide sin wave by higher val = smaller height
    [SerializeField] private float transitionTime; //time taken to get between start pos and end pos for transition state
    [SerializeField] private Vector3 transitionVelocity = Vector3.zero;
    private float heightVariance = 0.5f;

    float genRandPos()
    {
        float r = Random.Range(pos0, pos1);
        randPos = new Vector3(this.transform.position.x, r, this.transform.position.z);
        return r;

    }

    void transition(Vector3 argPos)
    {
        this.transform.position = Vector3.SmoothDamp(this.transform.position, argPos, ref transitionVelocity, transitionTime, Mathf.Infinity);
    }

    void switchState()
    {

        state = (state == eState.WOBBLE) ?
            state = eState.TRANSITION :
            state = eState.WOBBLE;

    }

    // Start is called before the first frame update
    void Start()
    {
        genRandPos();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        switch (state)
        {

            case eState.TRANSITION:
                transition(randPos);
                break;

            case eState.WOBBLE:
                this.transform.position = new Vector3(this.transform.position.x,
                    //default height is 1
                    this.transform.position.y + Mathf.Sin(wobbleSpeed * wobbleTimer) / wobbleHeightDivisor * Time.deltaTime,
                    this.transform.position.z);
                break;

            default:
                Debug.Log("Caught a default case for state switching");
                break;
        }

        if (eState.TRANSITION == state)
        {
            if (this.transform.position.y <= randPos.y + heightVariance &&
                this.transform.position.y >= randPos.y - heightVariance) //variance needed because smooth damp doesnt reap the end point
            {
                genRandPos();
                switchState();
            }
            return;
        }

        wobbleTimer += Time.deltaTime;

        if (wobbleTimer >= stateTransition)
        {
            switchState();
            wobbleTimer = 0.0f;
        }

    }
}