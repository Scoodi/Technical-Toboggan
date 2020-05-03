using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadManager
{
    public static void SaveScore(ScoreManager argScore)
    {
        //Create the data to save 
        PlayerData data = new PlayerData(argScore);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/score.sav", FileMode.Create);

        bf.Serialize(stream, data);
        stream.Close();
    }

    public static int[] LoadScores()
    { 
        if (File.Exists(Application.persistentDataPath + "/score.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/score.sav", FileMode.Open);

            PlayerData data = bf.Deserialize(stream) as PlayerData;

            stream.Close();

            return data.highScores;
        }
        else
        {
            Debug.Log("File does not exist");
            int[] nothing = new int[5];
            return nothing;
        }       
    }
}

[Serializable]
public class PlayerData
{
    public int[] highScores;
    public int[] currentScores;
    public PlayerData(ScoreManager argScore)
    {
        //if the scores of either player are higher than the current high scores we overwrite 
        currentScores = argScore.GetPlayerScores();
        highScores = SaveLoadManager.LoadScores();

        //TODO - Insert Score in correct position 
        for (int i = 0; i < highScores.Length; i++)
        {
            for (int s = 0; s < 2; s++)
            {
                if (currentScores[s] > highScores[i])
                {
                    int[] tempArray = new int[5];

                    //Get the scores higher than the current
                    for (int j = 0; j < i; j++)
                    {
                        tempArray[j] = highScores[j];
                    }

                    //Score that we have 
                    tempArray[i] = currentScores[s];

                    //Scores lower than current 
                    for (int j = i + 1; j < highScores.Length - 1; j++)
                    {
                        tempArray[j] = highScores[j - 1];
                    }

                    highScores = tempArray;

                }
            }
        }
    }
}

