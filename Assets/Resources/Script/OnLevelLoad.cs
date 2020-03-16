using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLevelLoad : MonoBehaviour
{
    
    private CharacterObject p1Character;

    public Transform playerOneSpawnPoint;
    public Transform playerTwoSpawnPoint;

    [SerializeField] private int p1Selection = 1;
    [SerializeField] private int p2Selection = 1;
    // Start is called before the first frame update
    void Start()
    {
        //Get the players choices of character 
        GameObject go = GameObject.FindGameObjectWithTag("GameController");
                               
        if (go == null)
        {
            /*If loading the level without going through the character selection scene
           In the final version of the game this check can be removed */
                  
            //Player One
            var p1Character = Resources.Load<CharacterObject>("Characters/Character" + p1Selection.ToString()); ;
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


}