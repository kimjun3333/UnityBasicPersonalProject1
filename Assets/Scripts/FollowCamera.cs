using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

    float offsetX;
    float offsetY;

    void Start()
    {
        if (target == null)
            Debug.LogError("Target이 없습니다.");

        offsetX = transform.position.x - target.transform.position.x;
        offsetY = transform.position.y - target.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 pos = transform.position;
        pos.x = target.transform.position.x + offsetX;
        pos.y = target.transform.position.y + offsetY;
        pos.z = transform.position.z;
        transform.position = pos;  
    }
}
