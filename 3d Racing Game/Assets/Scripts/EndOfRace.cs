using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfRace : MonoBehaviour
{


    void OnTriggerEnter()//when another object collides with this object 
    {
        SceneManager.LoadScene(2);//calls the scenemanager and loads the scene with the index of 2
    }
}
