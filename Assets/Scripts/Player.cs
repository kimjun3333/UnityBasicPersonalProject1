using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    
    public float speed = 2f;

    Animator anim;

    bool isHorizonMove;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move() //이동 로직꾸
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.velocity = new Vector2(h, v) * speed;


        if (v < 0)
            anim.SetInteger("Move", 0);
        else if (v > 0)
            anim.SetInteger("Move", 1);
        else if (h < 0)
            anim.SetInteger("Move", 2);
        else if (h > 0)
            anim.SetInteger("Move", 3);

        
    }


}
