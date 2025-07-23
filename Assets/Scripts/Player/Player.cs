using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    Vector3 dirVec;
    GameObject scanObj;

    public TalkManager talkManager;

    private float speed = 5f;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (rigid == null)
            Debug.LogError("rigid가 없습니다??");

        if (talkManager == null)
            Debug.LogError("talkManager 이없습니다!!");

        if (anim == null)
            Debug.LogError("anim이 없습니다!");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        FindObj();
        CheckNPC();
    }
}
