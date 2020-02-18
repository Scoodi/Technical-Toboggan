using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update



    //Change to the character selection scene 
    public void CharacterSelect ()
    {
        SceneManager.LoadScene("CharacterSelection");
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Level01");
    }
  
}
