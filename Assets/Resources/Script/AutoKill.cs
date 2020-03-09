using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoKill : MonoBehaviour
{
    public float timeToKill = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Kill(timeToKill));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Kill(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
