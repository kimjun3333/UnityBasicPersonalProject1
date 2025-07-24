using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini1Player : MonoBehaviour
{
    Animator animator; // isDie Anim
    Rigidbody2D rigid;
    Mini1GameManager gameManager;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    
    private float deathCooldown = 0f;

    public bool isFlap = false;
    public bool GodMode = false;

    public Mini1GameManager GameManager
    {
        get { return gameManager; }
    }

    private void Awake()
    {
       gameManager = FindObjectOfType<Mini1GameManager>();

        if (gameManager == null)
            Debug.LogError("gameManager is Null");
    }

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
                    gameManager.RestartGame();
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

        //애니메이터 isDIe 사용시 넣기
        animator.SetBool("isDie", true);

        rigid.constraints &= ~RigidbodyConstraints2D.FreezeRotation; //z축 Freeze 풀기

        //게임 매니저 게임오버
        gameManager.GameOver();
        
    }
}
