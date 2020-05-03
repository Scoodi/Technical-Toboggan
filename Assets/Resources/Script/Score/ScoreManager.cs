using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{  
    private TankScript playerOne;
    private TankScript playerTwo;

    [SerializeField] private int scoreForKill = 5;

    #region Singleton  
    public static ScoreManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }
    #endregion 

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        playerOne = players[0].GetComponent<TankScript>();
        playerTwo = players[1].GetComponent<TankScript>();
        
        //If the players are found in the incorrect order we need to swap them 
        if (playerOne.playerNumber != 1)
        {
            playerOne = players[1].GetComponent<TankScript>();
            playerTwo = players[0].GetComponent<TankScript>();
        }
    }

    public void GivePlayerScoreForKill(int argPlayerThatDied)
    {
        /*
         * When a player dies, we call this function to give the other player points 
         */
        switch (argPlayerThatDied)
        {
            case 1:
                playerTwo.score += scoreForKill;
                playerTwo.RequestHUDUpdate();
                break;
            case 2:
                playerOne.score += scoreForKill;
                playerOne.RequestHUDUpdate();
                break;
            default:
                Debug.Log("Error adding score");
                break;
        }
    }

    public void GiveZoneScore(int argPlayerNumber)
    {
        
        if (1 == argPlayerNumber)
        {
            playerOne.score += 1;
            playerOne.RequestHUDUpdate();
        }
        else if (2 == argPlayerNumber)
        {
            playerTwo.score += 1;
            playerTwo.RequestHUDUpdate();
        }

    }

    public int[] GetPlayerScores()
    {
        //Return the current player scores 
        int[] scores = new int[2];

        scores[0] = playerOne.score;
        scores[1] = playerTwo.score;

        return scores; 
    }
}
