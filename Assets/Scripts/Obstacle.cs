using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public GameObject triangleObj;

    float xOffset;

    public int qntObstacle;

    public int scoreQnt;
    public GameManager score;

    void Start()
    {

        qntObstacle = 5;

        if(gameObject.name == "left")
        {
            xOffset = 0.5f;
            
        }
        else
        {
            xOffset = -0.5f;
        }
        //InitObstacle();
    }

     void Update() {
        scoreQnt = score.score;
        if(scoreQnt == 5){
            qntObstacle = 12;
        }
    }

    void InitObstacle()
    {
        
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        for(int i = 0; i < qntObstacle; i++)
        {
            int randomY = Random.Range(-8, 7);
            GameObject tempObj =  Instantiate(triangleObj, new Vector2(transform.position.x + xOffset, randomY * 1.5f), transform.rotation);
            tempObj.transform.SetParent(transform);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        InitObstacle();
    }
}
