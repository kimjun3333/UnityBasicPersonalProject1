using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    Vector3 dirVec;
    GameObject scanObj;

    private float speed = 5f;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        FindObj();
        Action();
    }

    private void Move() //이동 로직
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

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

    private void Action()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(scanObj != null)
            {
                Debug.Log(scanObj.name);
            }
        }
    }

    private void FindObj() // Ray로 Obj 탐색
    {
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("NPC"));

        if (rayHit.collider != null)
        {
            scanObj = rayHit.collider.gameObject;
        }
        else
        {
            scanObj = null;
        }
    }
}
