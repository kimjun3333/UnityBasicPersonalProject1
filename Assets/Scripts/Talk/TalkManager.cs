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

        if (talkData == null) // Id에 해당하는 NPC 대사가 없을경우 null 반환
        {
            interaction.talkOrder = 0;
            isAction = false;
            Notify("", "", null, false);
            return;
        }

        if (isNPC)
        {
            Notify(talkData, interaction.name, interaction.characterImage, true);
        }
        else
        {
            //오브젝트 경우 추가 처리 // 이부분도 필요 없어질듯하다
        }

        interaction.talkOrder++; // 수정예정

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
}