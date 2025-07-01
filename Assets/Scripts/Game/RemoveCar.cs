using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCar : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag != "Road" && collision.gameObject.tag != "Express")
        {
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "Express")
        {
            Destroy(collision.gameObject);
        }
    }
}
