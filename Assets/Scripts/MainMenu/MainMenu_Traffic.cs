using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_Traffic : MonoBehaviour
{
    public GameObject carObstacle;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        carObstacle.transform.position = carObstacle.transform.position + new Vector3(0f, 0f, speed);
        //points += (int)(trafficSpeed * 100);
        //pointsText.text = points.ToString();
    }
}
