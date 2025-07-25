using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    private List<ITalkObserver> talkObservers = new List<ITalkObserver>();

    public TalkDataBase talkDataBase;

    private Interaction interaction;
    public GameObject scanObject;
    public bool isAction;

    public QuestManager questManager;

    public void Subscribe(ITalkObserver talkObserver)
    {
        if (!talkObservers.Contains(talkObserver))
            talkObservers.Add(talkObserver);
    }

    public void UnSubscribe(ITalkObserver talkObserver)
    {
        if (talkObservers.Contains(talkObserver))
            talkObservers.Remove(talkObserver);
    }

    private void Notify(string talkText, string name, Sprite image, bool isActive)
    {
        foreach (var talkObserver in talkObservers)
        {
            talkObserver.OnTalkChanged(talkText, name, image, isActive);
        }
    }

    public void Action(GameObject scanObj)
    {
        if (isAction)
        {
            isAction = false;
            Notify("", "", null, false);
        }
        else
        {
            isAction = true;
            scanObject = scanObj;
            interaction = scanObj.GetComponent<Interaction>();
            StartTalk(interaction.id, interaction.isNPC);
        }
    }

    public void StartTalk(int id, bool isNPC)
    {
        string talkData = talkDataBase.GetData(id, interaction.talkOrder);

        if (talkData == null) // Id�� �ش��ϴ� NPC ��簡 ������� null ��ȯ
        {
            interaction.talkOrder = 0;
            isAction = false;
            Notify("", "", null, false);
            return;
        }

        if (isNPC)
        {
            Notify(talkData, interaction.name, interaction.characterImage, true);
            CheckQuest();
        }
        else
        {
            //������Ʈ ��� �߰� ó�� // �̺κе� �ʿ� ���������ϴ�
        }

        interaction.talkOrder++; // ��������

    }

    public void EndTalk()
    {
        isAction = false;
        interaction.talkOrder = 0;
        Notify("", "", null, false);
    }

    public void NextTalk()
    {
        if (!isAction)
            return;
       
        StartTalk(interaction.id, interaction.isNPC);
    }

    public void CheckQuest()
    {
        if(interaction.talkOrder == 1 && interaction.id == 1000)
        {
            Quest newQuest = new Quest
            {
                questName = "�����հ� ��ȭ�ϱ�",
                questType = EventBus.QuestType.Talking,
                targetID = interaction.id + 10,
                isComplete = false

                
            };

            questManager.ReceiveQuest(newQuest);

            interaction.id += 10;

            return;
        }
        if(interaction.id == 1010)
        {
            questManager.CompleteQuest(EventBus.QuestType.Talking, 1010);
        }
    }
}