using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    public Text[] playerHP;
    public Text[] playerPowerup;
    public Text[] playerScore;
    public Text timeRemaining;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateHUD(float argTimeRemaining)
    {
        string minutes = Mathf.Floor(argTimeRemaining/60).ToString("00");
        string seconds = (argTimeRemaining % 60 ).ToString("00");

        timeRemaining.text = minutes + ":" + seconds;
    }

    public void UpdateHUD(int playerNum, float hp, string powerup, int score)
    {
        playerNum--;
        playerHP[playerNum].text = "HP: " + hp.ToString();
        playerPowerup[playerNum].text = "Powerup: " + powerup;
        playerScore[playerNum].text = "Score: " + score;
    }
 }
