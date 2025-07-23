using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini1Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigid;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    
    private float deathCooldown = 0f;

    public bool isFlap = false;
    public bool GodMode = false;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rigid = GetComponentInChildren<Rigidbody2D>();

        if (animator == null)
            Debug.LogError("Animator is null");
        if (rigid == null)
            Debug.LogError("rigid is null");
    }

    private void Update()
    {
        if(isDead)
        {
            if (deathCooldown <= 0f)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    //게임매니저 다시시작
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead)
            return;

        Vector3 velocity = rigid.velocity;
        velocity.x = forwardSpeed;

        if(isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        rigid.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((GodMode))
            return;

        if (isDead) 
            return;

        isDead = true;
        deathCooldown = 1f;

        //게임 매니저 게임오버
        //애니메이터 isDIe 사용시 넣기
    }
}
