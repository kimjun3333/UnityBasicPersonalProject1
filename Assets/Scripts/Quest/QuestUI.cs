using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour //ITalkObserver
{
    public Text questText;
    public Text highscoreText; 
    public Image[] questImage;

    private void Start()
    {
        UpdateScoreText();
    }
    public void UpdateQuestText(List<Quest> questList)
    {
        questText.text = "";

        foreach(var quest in questList)
        {
            questText.text = quest.questName;
                questImage[0].gameObject.SetActive(quest.isComplete);
                questImage[1].gameObject.SetActive(!quest.isComplete);
        }

        
    }

    public void UpdateScoreText()
    {
        int highscore = PlayerPrefs.GetInt("HighScore", 0);
        highscoreText.text = "플래피버드 :" + highscore.ToString();
    }
}
