using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    // 이름 추후 변경 예정.

    public TalkDataBase talkManager;
    public GameObject talkBox;
    public Text talkText;
    public Text nameText;
    private Interaction interaction;

    public Image showImage;

    public GameObject scanObject;

    public bool isAction;
    public int talkIndex;

    public void Action(GameObject scanObj)
    {
        if(isAction)
        {
            isAction = false;
        }
        else
        {
            isAction = true;
            scanObject = scanObj;
            interaction = scanObject.GetComponent<Interaction>();
            Talk(interaction.id, interaction.isNPC);
        }
        talkBox.SetActive(isAction);
    }

    private void Talk(int id, bool isNPC)
    {
        string talkData = talkManager.GetData(id, talkIndex);

        if(isNPC)
        {
            talkText.text = talkData;
            SetImage(interaction);
            SetName(interaction);
        }
        else
        {
            //추가 예정
        }
    }
    private void SetName(Interaction interaction)
    {
        nameText.text = interaction.name;
    }

    private void SetImage(Interaction interaction)
    {
        Sprite sprite = GetImage(interaction);
        showImage.sprite = sprite;
    }

    private Sprite GetImage(Interaction interaction)
    {
        return interaction.characterImage;
    }
}
