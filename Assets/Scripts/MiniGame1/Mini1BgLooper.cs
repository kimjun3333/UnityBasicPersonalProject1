using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini1BgLooper : MonoBehaviour
{
    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;
    public int numBgCount = 5;

    private void Start()
    {
        Mini1Obstacle[] obstacles = GameObject.FindObjectsOfType<Mini1Obstacle>();
        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        for(int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered" + collision.name);

        if(collision.CompareTag("Mini1BG"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }
        Mini1Obstacle obstacle = collision.GetComponent<Mini1Obstacle>();
        if(obstacle != null)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }   
    }
}
