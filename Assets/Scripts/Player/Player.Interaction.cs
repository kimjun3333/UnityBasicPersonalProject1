using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    private void CheckNPC()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("스페이스바 눌림");
            if (scanObj != null)
            {
                if(!talkManager.isAction) // Action이 아닐때
                {
                    talkManager.Action(scanObj);
                }
                else
                {
                    talkManager.NextTalk();
                }         
            }
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(talkManager.isAction)
            {
                talkManager.EndTalk();
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
