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
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/score.sav", FileMode.Create);

        PlayerData data = new PlayerData(argScore);
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
            return null;
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
        for (int i = 0; i < 5; i++)
        {
            if (currentScores[0] > highScores[i])
            {
                int[] tempArray = new int[5];
            }
           
        }
    }
}

