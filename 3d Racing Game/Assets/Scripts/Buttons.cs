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
    public void TrackList()
    {
        SceneManager.LoadScene(1);
    }
    public void PickTrack1()
    {
        SceneManager.LoadScene(2);
    }
    public void PickProceduralTrack()
    {
        SceneManager.LoadScene(3);
    }
    public void CarSelect()
    {
        SceneManager.LoadScene(4);

    }

}
