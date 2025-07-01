using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript_Jump : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Car")
        {
            GlobalVariables.AddJumps(1);
            Destroy(this.gameObject);
        }
    }
}
