using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrafficMovement : MonoBehaviour
{
    public GameObject carObstacle;
    private int speedText = 61;

    // Start is called before the first frame update
    void Start()
    {
        //points = 0;
    }

    void Update()
    {
        // SPEED UP
        if(Input.GetKey(KeyCode.W))
        {
            if(GlobalVariables.carSpeed < 2f)
            {
                GlobalVariables.carSpeed += 0.0001f;
                UpdateUI();
            }
        }

        // SLOW DOWN
        else if(Input.GetKey(KeyCode.S))
        {
            if(GlobalVariables.carSpeed > 0.2f)
            {
                GlobalVariables.carSpeed -= 0.0001f;
                UpdateUI();
            }
        }

        // NATURAL SLOW
        else
        {
            if(GlobalVariables.carSpeed > 0.2f)
            {
                GlobalVariables.carSpeed -= 0.00001f;
                UpdateUI();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        carObstacle.transform.position = carObstacle.transform.position + new Vector3(0f, 0f, -GlobalVariables.carSpeed);
        //points += (int)(trafficSpeed * 100);
        //pointsText.text = points.ToString();
    }

    void UpdateUI()
    {
        GlobalVariables.multiplier = (int)(GlobalVariables.carSpeed/0.4f)+1;
        UI_Script.instance.multiplier.SetText("x" + GlobalVariables.multiplier.ToString());
        speedText = (int)((GlobalVariables.carSpeed-0.2f) * 10f + 61f);
        UI_Script.instance.speed.SetText(speedText.ToString() + " mph");
    }
}
