using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameZone : MonoBehaviour
{
   void playGame()
    {
        SceneManager.LoadScene("GameScene1");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playGame();
        }
    }
}
