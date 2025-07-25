using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkUI : MonoBehaviour , ITalkObserver
{
    public GameObject talkBox;
    public Text talkText;
    public Text nameText;
    public Image showImage;

    private TalkManager talkManager;

    private void Start()
    {
        talkManager = FindObjectOfType<TalkManager>();
        talkManager.Subscribe(this);
    }

    private void OnDestroy()
    {
        if (talkManager == null)
            talkManager.UnSubscribe(this);
    }

    public void OnTalkChanged(string talkText, string name, Sprite image, bool isActive)
    {
        talkBox.SetActive(isActive);

        if(isActive)
        {
            this.talkText.text = talkText;
            this.nameText.text = name;

            if(image != null)
            {
                showImage.gameObject.SetActive(true);
                this.showImage.sprite = image;
            }
            else
            {
                showImage.gameObject.SetActive(false);
            }
        }
    }
}
