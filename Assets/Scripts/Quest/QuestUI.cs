using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour //ITalkObserver
{
    public Text questText;
    public Image[] questImage;

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
}
