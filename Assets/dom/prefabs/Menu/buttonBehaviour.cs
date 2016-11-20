using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class buttonBehaviour : MonoBehaviour {

    public void quitGame()
    {
        Application.Quit();
    }

    public void enterCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void startGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
