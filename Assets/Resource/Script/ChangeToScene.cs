using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToScene : MonoBehaviour
{
    public string nameOfScene;
  

    public void ChangeScene()
    {
        SceneManager.LoadScene(nameOfScene);
    }

}
