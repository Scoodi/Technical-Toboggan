using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class OnLevelLoad : MonoBehaviour
{    
    private CharacterObject p1Character;

    public Transform playerOneSpawnPoint;
    public Transform playerTwoSpawnPoint;

    [SerializeField] private int p1Selection = 1;
    [SerializeField] private int p2Selection = 1;

    [SerializeField] private float totalGameTime = 600;
    private float timeRemaining;

    private bool gameOver = false;

    private HUDScript hudController;

    // Start is called before the first frame update
    void Awake()
    {
        //Set the time remaining and get the hud script to display the remaining time 
        timeRemaining = totalGameTime;
        hudController = (HUDScript)FindObjectOfType(typeof(HUDScript));

        //Get the players choices of character 
        GameObject go = GameObject.FindGameObjectWithTag("GameController");
                               
        if (go == null)
        {
            /*If loading the level without going through the character selection scene
           In the final version of the game this check can be removed */
                  
            //Player One
            var p1Character = Resources.Load<CharacterObject>("Characters/Character" + p1Selection.ToString()); 
            p1Character.CreateInstance(playerOneSpawnPoint, 1);

            //Player Two
            var p2Character = Resources.Load<CharacterObject>("Characters/Character" + p2Selection.ToString());
            p2Character.CreateInstance(playerTwoSpawnPoint, 2);
        }
        else
        {
            SelectionStorage ss = go.GetComponent<SelectionStorage>() as SelectionStorage;

            //Player One Load
            var p1Character = Resources.Load<CharacterObject>("Characters/Character" + ss.GetSelection(1).ToString());
            p1Character.CreateInstance(playerOneSpawnPoint, 1);
            
            //Player Two Load
            var p2Character = Resources.Load<CharacterObject>("Characters/Character" + ss.GetSelection(2).ToString());
            p2Character.CreateInstance(playerTwoSpawnPoint, 2);
        }     
      
    }

    private void Update()
    {  
        if (!gameOver)
        {
            timeRemaining -= Time.deltaTime;
            hudController.UpdateHUD(Mathf.RoundToInt(timeRemaining));

            if (timeRemaining <= 0)
            {
                gameOver = true;
                EndLevel();
            }
        }
    }

    private void EndLevel()
    {       
        //Show the winner 
        //Get the player scores
        int[] scores = ScoreManager.instance.GetPlayerScores();

        if (scores[0] > scores[1])
        {
            hudController.GameOverMessage(0);
            
        }
        else if (scores[0] < scores[1])
        {
            hudController.GameOverMessage(1);
        }
        else
        {
            hudController.GameOverMessage(2);
        }
        
        //Save to scores if high score is set 
        SaveLoadManager.SaveScore(ScoreManager.instance);

        //After a few seconds return to the menu for the next player 
        StartCoroutine(WaitToRestart());
    }

    IEnumerator WaitToRestart()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Menu");
    }
}