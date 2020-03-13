using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawItemCollet : MonoBehaviour
{

    public GameObject itemCollect;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;

    public Plyer player;

    public bool isPlay;
    void Start()
    {
        
    }

    void Update()
    {

        isPlay = player.isPlay;

        if (isPlay == true)
        {
            Spawnner();
        }
      
    }

    public void Spawnner()
    {
        if (timeBtwSpawn <= 0)
        {
            Instantiate(itemCollect, transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }

}
