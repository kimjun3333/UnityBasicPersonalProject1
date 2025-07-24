using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mini1GameManager : MonoBehaviour
{
    private int currentScore = 0;
    Mini1UIManager uiManager;

    public Mini1UIManager UIManager
    {
        get { return uiManager; }
    }

    private void Awake()
    {
        uiManager = FindObjectOfType<Mini1UIManager>();

        if (uiManager == null)
            Debug.LogError("uiManager is Null");
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
    }

    public void GameOver()
    {
        Debug.Log("게임오버");
        uiManager.SetRestart();
    }

    public void RestartGame()
    {
        Debug.Log("다시시작");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);
        Debug.Log("점수" + currentScore);
    }

}
