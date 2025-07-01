using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointSystem : MonoBehaviour
{
    [SerializeField] TMP_Text distanceText;
    [SerializeField] TMP_Text pointsText;
    private float distanceTimer;
    private float pointsTimer;
    private bool invoked;

    // Start is called before the first frame update
    void Start()
    {
        invoked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(invoked)
        {
            distanceTimer += Time.deltaTime;
            pointsTimer += Time.deltaTime;
            if(distanceTimer >= 0.2f/GlobalVariables.carSpeed)
            {
                distanceTimer = 0f;
                AddDistance();
            }
            if(pointsTimer >= 0.1f)
            {
                pointsTimer = 0f;
                AddPoints();
            }

            if(!GlobalVariables.isDriving)
            {
                invoked = false;
            }
        }
    }

    void AddDistance()
    {
        GlobalVariables.distance += 1;
        //GlobalVariables.points += (int)(GlobalVariables.carSpeed * 5f);
        //Debug.Log("carSpeed: " + GlobalVariables.carSpeed);
        //Debug.Log("added " + (int)(GlobalVariables.carSpeed * 5f));
        distanceText.SetText(GlobalVariables.distance.ToString() + "M");
    }

    void AddPoints()
    {
        GlobalVariables.points += (1 * GlobalVariables.multiplier);
        pointsText.SetText(GlobalVariables.points.ToString());
    }
}
