using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Track1()
    {
        SceneManager.LoadScene(1);
    }

    public void ProceduralTrack()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Application.Quit();
    }
   
}
