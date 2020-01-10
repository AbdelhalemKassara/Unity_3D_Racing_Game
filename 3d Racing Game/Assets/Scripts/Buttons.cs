using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public void Menu()
    {
        SceneManager.LoadScene(0);//loads the scene with an index of 0
    }

    public void Track1()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void Relaod()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Track2()
    {
        SceneManager.LoadScene(3);
    }
    public void Track3()
    {
        SceneManager.LoadScene(4);
    }

}
