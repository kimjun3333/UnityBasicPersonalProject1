using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MountType
{
    None,
    Â÷,
    ¸»
}
public class Interaction : MonoBehaviour
{
    public string name;
    public int id;
    public bool isNPC;
    public Sprite characterImage;
    public int talkOrder = 0;

    public MountType reward = MountType.None;
}
