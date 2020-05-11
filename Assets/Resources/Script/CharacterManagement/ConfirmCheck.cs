using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmCheck : MonoBehaviour
{
    private CharacterSelector[] selectors;
    private SelectionStorage selectionStorage;

    private void Start()
    {
        selectors = gameObject.GetComponentsInChildren<CharacterSelector>();
        selectionStorage = (SelectionStorage)FindObjectOfType(typeof(SelectionStorage));
    }

    // Update is called once per frame
    void Update()
    {
        if (selectors[0].isConfirmed && selectors[1].isConfirmed)
        {
            SceneManager.LoadScene(selectionStorage.GetLevelSelection());
        }
    }
}

