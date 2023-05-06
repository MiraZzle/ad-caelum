using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void showSources()
    {
        SceneManager.LoadScene("Sources");
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void highscore()
    {
        SceneManager.LoadScene("Highscore");
    }
}
