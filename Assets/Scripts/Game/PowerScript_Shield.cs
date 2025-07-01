using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript_Shield : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Car")
        {
            GlobalVariables.isShielded = true;
            Destroy(this.gameObject);
        }
    }
}
