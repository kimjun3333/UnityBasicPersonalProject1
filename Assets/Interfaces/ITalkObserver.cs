using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITalkObserver
{
    void OnTalkChanged(string talkText, string name, Sprite image, bool isActive);
}
