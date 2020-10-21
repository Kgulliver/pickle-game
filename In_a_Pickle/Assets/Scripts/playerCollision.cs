using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour    
{
    private int moistureRegen = 10;
    public playerVitals vitals;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "moist")
        {
            Debug.Log("This is moist");
            Destroy(other.gameObject);
            vitals.hydrationSlider.value += vitals.hydrationSlider.value + moistureRegen;

        }
    }

}
