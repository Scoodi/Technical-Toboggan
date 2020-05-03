using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI[] scoreUI;

    // Start is called before the first frame update
    void Start()
    {
        int[] scores = new int[5];
        scores = SaveLoadManager.LoadScores();

        for(int i = 0; i< 5; i++)
        {
            scoreUI[i].text = scores[i].ToString();
        }


    }

   
}
