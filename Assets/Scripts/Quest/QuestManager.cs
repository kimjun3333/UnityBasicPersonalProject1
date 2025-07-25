using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Quest
{
    public string questName;
    public EventBus.QuestType questType;
    public int targetID;
    public bool isComplete;
}

public class QuestManager : MonoBehaviour
{
    public List<Quest> questList = new List<Quest>();

    public QuestUI questUI;


    private void Start()
    {
        QuestAdd();
    }

    private void QuestAdd()
    {
        questList.Add(new Quest { questName = "NPC�� ��ȭ�ϱ�", questType = EventBus.QuestType.Talking, targetID = 1200 });
    }

    public void ReceiveQuest(Quest newQuest)
    {
        if(!questList.Exists(q => q.questName == newQuest.questName))
        {
            questList.Add(newQuest);
            Debug.Log("�� ����Ʈ�� �޾ҵ�");
            questUI.UpdateQuestText(questList);
        }
        else
        {
            Debug.Log("�̹� ���� ����Ʈ");
        }
    }
    public void CompleteQuest(EventBus.QuestType questType, int targetID)
    {
        foreach (var quest in questList)
        {
            if (!quest.isComplete && quest.questType == questType && quest.targetID == targetID)
            {
                quest.isComplete = true;
                Debug.Log("����Ʈ �Ϸ�" + quest.questName);
                questUI.UpdateQuestText(questList);

                //����

                break;
            }
        }
    }
    private void OnEnable()
    {
        EventBus.Register(EventBus.QuestType.Talking, OnTalking);
        EventBus.Register(EventBus.QuestType.Gaming, OnGaming);
        EventBus.Register(EventBus.QuestType.Riding, OnRiding);
    }

    private void OnDisable()
    {
        EventBus.UnRegister(EventBus.QuestType.Talking, OnTalking);
        EventBus.UnRegister(EventBus.QuestType.Gaming, OnGaming);
        EventBus.UnRegister(EventBus.QuestType.Riding, OnRiding);
    }

    private void OnTalking(int npcID)
    {
        CompleteQuest(EventBus.QuestType.Talking, npcID);
    }

    private void OnGaming(int game = 0)
    {
        CompleteQuest(EventBus.QuestType.Gaming, game);
    }

    private void OnRiding(int mountID)
    {
        CompleteQuest(EventBus.QuestType.Riding, mountID);
    }
}
