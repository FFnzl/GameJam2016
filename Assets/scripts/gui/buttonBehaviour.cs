using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EnterCredits()
    {
        SceneManager.LoadScene("scn_credits");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("scn_level");
    }
}
