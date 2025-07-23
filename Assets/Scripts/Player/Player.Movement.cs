using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    private void Move() //이동 로직
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        

        if (talkManager.isAction)
        {
            rigid.velocity = Vector2.zero;
            return;
        }


        rigid.velocity = new Vector2(h, v) * speed;

        if (v < 0)
        {
            anim.SetInteger("Move", 0);
            dirVec = Vector3.down;
        }
        else if (v > 0)
        {
            anim.SetInteger("Move", 1);
            dirVec = Vector3.up;
        }
        else if (h < 0)
        {
            anim.SetInteger("Move", 2);
            dirVec = Vector3.left;
        }
        else if (h > 0)
        {
            anim.SetInteger("Move", 3);
            dirVec = Vector3.right;
        }
    }
}
