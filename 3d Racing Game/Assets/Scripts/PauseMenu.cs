using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(InputManager))]

public class PauseMenu : MonoBehaviour
{
    public InputManager In;

    public GameObject PauseMenuUI;
    void start()
    {
        In = GetComponent<InputManager>();

    }

    void Update()
    {
        if (In.GamePaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
        Debug.Log(In.GamePaused);

    }
    void Pause()
    {


        PauseMenuUI.SetActive(true);// activates the game object storing the menu
        Time.timeScale = 0f; // changes the time in the game (used for slow motion effects)

    }
    void Resume()
    {
        PauseMenuUI.SetActive(false);// deactiveates the game object storing the menu
        Time.timeScale = 1f; // changes the time in the game to 1 (1 second real life = 1 second in game)

    }
}
