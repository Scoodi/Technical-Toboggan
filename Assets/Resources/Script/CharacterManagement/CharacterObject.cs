using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class CharacterObject : ScriptableObject
{
    public GameObject characterModel;

    public int characterIndex = 1;

    //We can have other variables here such as speed, damagePerShot and health

    public GameObject CreateInstance(Transform argStartPoint, int argPlayerNumber)
    {
        //Setup Camera 
        Camera cam = characterModel.GetComponentInChildren<Camera>();
        cam.rect = new Rect(0.0f, 0.5f * (argPlayerNumber % 2), 1, 0.5f);
        
        //Set the tag of the object to player 
        characterModel.tag = "Player";

        //Setup Tank script for correct player number
        TankScript t = characterModel.GetComponentInChildren<TankScript>();
        t.playerNumber = argPlayerNumber;
        t.spawnPoint = argStartPoint ; // temporary, once a better spawn system is implemented this will be changed 
        ShootScript s = characterModel.GetComponentInChildren<ShootScript>();
        s.playerNumber = argPlayerNumber;

        //Create the object once its been set up
        return ScriptableObject.Instantiate(this.characterModel, argStartPoint);
    }

    

} 

