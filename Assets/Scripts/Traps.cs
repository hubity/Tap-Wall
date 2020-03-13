using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{

    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpot;
    public int randomSpot;

    public void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpot.Length);
    }

    public void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpot.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }
    }

}


