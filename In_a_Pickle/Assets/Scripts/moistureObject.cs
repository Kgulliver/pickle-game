using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moistureObject : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "Player")
        {
            Debug.Log("MOIST");
        }
    }
}
