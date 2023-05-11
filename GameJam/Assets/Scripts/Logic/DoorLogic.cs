using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorLogic : MonoBehaviour
{
    LevelLogic logicManager;
    private Animator anim;

    public bool opened = false;
    public bool playerEnteredDoor = false;
    void Start()
    {
        logicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LevelLogic>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (logicManager.levelWon && opened == false)
        {
            opened = true;
            anim.SetBool("levelCompleted", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!opened) return;

        if (collision.gameObject.tag == "Player" && !playerEnteredDoor)
        {
            playerEnteredDoor = true;
            Invoke("CompleteLevel", 1f);
        }
    }

    void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}