using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour, IManager
{
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Debug.Log("Trying to open menu");
        }
        
    }

    // TODO: Send flags to FlagEvent
    // List of possible events (scriptable objects pulled from Resources folder)
    // List of events flagged (check if in first list)
    public void FlagEvent()
    {

    }

    public void StartGame()
    {

    }

    public void LoadGame()
    {

    }

    public void Options()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}