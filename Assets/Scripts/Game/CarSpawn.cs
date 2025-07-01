using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    public GameObject carObstacle;
    public Transform carObjectParent;
    private float timer = 0f;
    private int carsSpawned;
    private float spawnInterval;
    private bool powerUpSpawned;
    public List<GameObject> powerUps = new List<GameObject>();

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
        powerUpSpawned = false;
        for(int i = -6; i <= 6; i+=3)
        {
            if(Random.Range(0, 2) == 0 && carsSpawned < 4)
            {
                Instantiate(carObstacle, new Vector3(i, -0.1f, 260f), Quaternion.identity, carObjectParent);
                carsSpawned += 1;
            }
            else if(!powerUpSpawned && Random.Range(0, 20) == 0)
            {
                Instantiate(powerUps[Random.Range(0, 3)], new Vector3(i, 1f, 260f), Quaternion.identity, carObjectParent);
                powerUpSpawned = true;
            }
        }

        if(GlobalVariables.carSpeed < 1.75f)
        {
            spawnInterval = Random.Range(0.35f, 1.5f);
        }
        else
        {
            spawnInterval = Random.Range(0.1f, 0.75f);
        }
    }


}
