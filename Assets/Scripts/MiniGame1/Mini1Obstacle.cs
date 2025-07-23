using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini1Obstacle : MonoBehaviour
{
    public float highPosY = 4f;
    public float lowPosY = -4f;

    public float holeSizeMin = 5f;
    public float holesizeMax = 8f;

    public Transform TopObject;
    public Transform BottomObject;

    public float widthPadding = 4f;


    //게임매니저

    private void Start()
    {
        //게임매니저
    }

    public Vector3 SetRandomPlace(Vector3 lastPositon, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holesizeMax);
        float halfHoleSize = holeSize / 2f;

        TopObject.localPosition = new Vector3(0, halfHoleSize);
        BottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPositon + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //점수얻는 로직
    }
}


