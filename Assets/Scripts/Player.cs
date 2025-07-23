using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    Vector3 dirVec;
    GameObject scanObj;

    public GameManager gameManager;

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
        CheckNPC();
    }

    private void Move() //이동 로직
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (gameManager.isAction)
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

    private void CheckNPC()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("스페이스바 눌림");
            if(scanObj != null)
            {
                gameManager.Action(scanObj);
            }
        }
    }

    private void FindObj() // Ray로 Obj 탐색
    {
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

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
