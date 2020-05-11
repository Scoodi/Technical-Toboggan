using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterSelector : MonoBehaviour
{
    public int playerNumber;

    GameObject[] characters;

    SelectionStorage selectionStorage;

    private int index;

    public TextMeshProUGUI confirmText;

    //Button inputs
    private string verticalAccessName;
    private string horizontalAccessName;
    private string aAccessName;

    //Button presses
    private bool isRight = false;
    private bool isLeft = false;

    public bool isConfirmed = false;

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
        //Only move one position in the direction entered when the button is released
        if (!isConfirmed)
        {
            if (Input.GetAxis(horizontalAccessName) > 0)
            {
                isRight = true;
            }
            else if (Input.GetAxis(horizontalAccessName) < 0)
            {
                isLeft = true;
            }

            if (Input.GetAxis(horizontalAccessName).Equals(0))
            {
                if (isRight)
                {
                    isRight = false;
                    MoveRight();
                }

                if (isLeft)
                {
                    isLeft = false;
                    MoveLeft();
                }
            }
        }

        if (Input.GetButtonUp(aAccessName))
        {
            selectionStorage.SetSelection(index + 1, playerNumber);
            confirmText.gameObject.SetActive(true);
            isConfirmed = true;
        }

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
    public bool HasConfirmedSelection()
    {
        return isConfirmed;
    }

}
