using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_CarSpawn : MonoBehaviour
{
    public GameObject carObstacle;
    public Transform carObjectParent;
    private float timer = 0f;
    private int carsSpawned;
    private float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        spawnInterval = Random.Range(0.35f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnInterval)
        {
            SpawnThings();
            timer = 0f;
        }
    }

    void SpawnThings()
    {
        carsSpawned = 0;
        for(int i = -6; i <= 6; i+=3)
        {
            if(Random.Range(0, 2) == 0 && carsSpawned < 4)
            {
                Instantiate(carObstacle, new Vector3(i, -0.1f, -205f), Quaternion.identity, carObjectParent);
                carsSpawned += 1;
            }
        }
        spawnInterval = Random.Range(0.15f, 0.75f);
    }
}
