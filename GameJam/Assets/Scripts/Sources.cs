using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sources : MonoBehaviour
{
    public void goToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
