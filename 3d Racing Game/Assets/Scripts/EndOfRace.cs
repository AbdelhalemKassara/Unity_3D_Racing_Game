using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfRace : MonoBehaviour
{


    void OnTriggerEnter()
    {
        SceneManager.LoadScene(3);
    }
}
