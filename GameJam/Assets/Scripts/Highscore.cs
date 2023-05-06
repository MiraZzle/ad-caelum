using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Highscore : MonoBehaviour
{
    public void goToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
