using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionStorage : MonoBehaviour
{
    private static int player1Selection = 2;
    private static int player2Selection = 2;

    private string levelSelection; 

    public int GetSelection(int argPlayerNumber)
    {
        if (1 == argPlayerNumber)
        {
            return player1Selection;
        }

        else if (2 == argPlayerNumber)
        {
            return player2Selection;
        }

        else
        {
            return 1;
        }
    }

    public void SetSelection(int argSelection, int argPlayerNumber)
    {
        if ( 1 == argPlayerNumber )
        {
            player1Selection = argSelection;
        }

        if ( 2 == argPlayerNumber )
        {
            player2Selection = argSelection;
        }
    }

    public void SetLevelSelection(string argLevel)
    {
        levelSelection = argLevel;
    }

    public string GetLevelSelection()
    {
        if (levelSelection != "")
            return levelSelection;
        else return "Islands"; //Testing purposes 
    }
}
