using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script checks if a game controller already exists, and if it doesn't, sets this to not be destroyed on scene changes. Otherwise it destroys this object.

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] controllers = GameObject.FindGameObjectsWithTag("GameController");
        if (controllers.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
