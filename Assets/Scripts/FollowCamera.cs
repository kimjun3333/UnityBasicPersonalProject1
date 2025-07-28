using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    float offsetX;
    float offsetY;

    void Start()
    {
        if (target == null)
            Debug.LogError("Target이 없습니다.");

        offsetX = transform.position.x - target.transform.position.x;
        offsetY = transform.position.y - target.transform.position.y;
    }

    void Update()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 pos = transform.position;
        pos.x = target.transform.position.x + offsetX;
        pos.y = target.transform.position.y + offsetY;
        
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        pos.z = transform.position.z;

        transform.position = pos;  
    }
}
