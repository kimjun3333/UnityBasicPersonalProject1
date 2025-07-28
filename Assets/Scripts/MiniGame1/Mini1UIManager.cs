using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mini1UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI highscoreText;

    public void Start()
    {
        if (scoreText == null)
            Debug.LogError("ScoreText is Null");
        if (restartText == null)
            Debug.LogError("restartText is Null");
        if (highscoreText == null)
            Debug.LogError("highscoreText is Null");

        restartText.gameObject.SetActive(false);
    }
    public void SetRestart()
    {
        Debug.Log("다시시작");
        restartText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateHighScore(int highScore)
    {
        highscoreText.text = "HighScore :" + highScore.ToString();
    }
}
