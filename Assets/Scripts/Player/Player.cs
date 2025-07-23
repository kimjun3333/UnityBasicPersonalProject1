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
            Debug.LogError("rigid�� �����ϴ�??");

        if (talkManager == null)
            Debug.LogError("talkManager �̾����ϴ�!!");

        if (anim == null)
            Debug.LogError("anim�� �����ϴ�!");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        FindObj();
        CheckNPC();
    }
}
