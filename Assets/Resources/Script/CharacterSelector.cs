using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public int playerNumber;

    GameObject[] characters;

    SelectionStorage selectionStorage;

    private int index;

    //Button inputs
    private string verticalAccessName;
    private string horizontalAccessName;
    private string aAccessName;

    // Start is called before the first frame update
    void Start()
    {
        selectionStorage = (SelectionStorage)FindObjectOfType(typeof(SelectionStorage));

        characters = new GameObject[transform.childCount];

        index = 0;

        for (int i = 0; i < transform.childCount; i++)
        {
            characters[i] = transform.GetChild(i).gameObject;
        }

        //Set all charcters to inactive except the first one 
        foreach (GameObject go in characters)
        {
            go.SetActive(false);
        }

        characters[0].SetActive(true);
        
        //Set Input Axes
        verticalAccessName = "Vertical" + playerNumber;
        horizontalAccessName = "Horizontal" + playerNumber;
        aAccessName = "A" + playerNumber;

    }

    // Update is called once per frame
    void Update()
    {
    }


    public void MoveLeft()
    {
        //Disable current game object
        characters[index].SetActive(false);

        //Decrease index 
        index--;
        if (index < 0) index = transform.childCount - 1;
        
        //Enable new game object
        characters[index].SetActive(true);
    }


    public void MoveRight()
    {
        //Disable current game object
        characters[index].SetActive(false);

        //Increase index 
        index++;
        if (index > transform.childCount - 1) index = 0;

        //Enable new game object
        characters[index].SetActive(true);
    }
    public void ConfirmSelection()
    {
        selectionStorage.SetSelection(index + 1, playerNumber);
    }

}
