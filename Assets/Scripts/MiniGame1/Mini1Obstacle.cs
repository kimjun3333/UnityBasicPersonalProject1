using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini1Obstacle : MonoBehaviour
{
    Mini1GameManager gameManager;

    public float highPosY = 1f;
    public float lowPosY = -1f;

    public float holeSizeMin = 1f;
    public float holesizeMax = 2f;

    public Transform TopObject;
    public Transform BottomObject;

    public float widthPadding = 6f;

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

    private void OnTriggerExit2D(Collider2D collision)
    {
        Mini1Player Player = collision.GetComponent<Mini1Player>();
        if (Player != null)
        {
            gameManager.AddScore(1);
        }
    }
}


