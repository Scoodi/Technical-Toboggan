using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{  
    private TankScript playerOne;
    private TankScript playerTwo;

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

        Debug.Log("Size of array is:" + players.Length.ToString());

        playerOne = players[0].GetComponent<TankScript>();
        playerTwo = players[1].GetComponent<TankScript>();
        
        //If the players are found in the incorrect order we need to swap them 
        if (playerOne.playerNumber != 1)
        {
            playerOne = players[1].GetComponent<TankScript>();
            playerTwo = players[0].GetComponent<TankScript>();
        }
    }

    public void GivePlayerScore(int argPlayerThatDied)
    {
        /*
         * When a player dies, we call this function to give the other player points 
         */
        switch (argPlayerThatDied)
        {
            case 1:
                playerTwo.score += 1;
                playerTwo.RequestHUDUpdate();
                break;
            case 2:
                playerOne.score += 1;
                playerOne.RequestHUDUpdate();
                break;
            default:
                Debug.Log("Error adding score");
                break;

        }

    }
 
}
