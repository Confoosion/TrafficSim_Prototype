using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript_Express : MonoBehaviour
{
    public GameObject expressLane;

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Car")
        {
            Instantiate(expressLane, new Vector3(-9, 0, 400), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
