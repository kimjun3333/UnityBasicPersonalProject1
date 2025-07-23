using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini1FollowCamera : MonoBehaviour
{
    public Transform target;

    float offsetX;

    private void Start()
    {
        if (target == null)
            Debug.LogError("target is null");

        offsetX = transform.position.x - target.transform.position.x;
    }

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 pos = transform.position;
        pos.x = target.transform.position.x + offsetX;
        transform.position = pos;
    }
}
