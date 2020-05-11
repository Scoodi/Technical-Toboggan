using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    [SerializeField] private float pointRate = 1.0f;
    private TankScript player;

    private float elapsedTime = 0.0f;
    private int playersInZone;

    // Start is called before the first frame update

    public void OnTriggerStay(Collider other)
    {  
        //Check the object is a player
        if (other.gameObject.GetComponent<TankScript>() != null)
        {         
            elapsedTime += Time.deltaTime;

            player = other.gameObject.GetComponent<TankScript>();
           
            //Wait for time to be greater than the point rate then give a point 
            if ((elapsedTime > pointRate) && playersInZone == 1)
            {
                ScoreManager.instance.GiveZoneScore(player.playerNumber);
                elapsedTime = 0;
            }
        }
        else
        {
            return;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<TankScript>() != null)
            playersInZone++;
        Debug.Log(playersInZone);
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<TankScript>() != null)
            playersInZone--;
        Debug.Log(playersInZone);
    }

}
