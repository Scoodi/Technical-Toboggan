using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    public Text[] playerHP;
    public Text[] playerPowerup;
    public Text[] playerScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHUD(int playerNum, float hp, string powerup, int score)
    {
        playerNum--;
        playerHP[playerNum].text = "HP: " + hp.ToString();
        playerPowerup[playerNum].text = "Powerup: " + powerup;
        playerScore[playerNum].text = "Score: " + score;
        
    }
}
