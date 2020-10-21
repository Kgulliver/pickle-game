using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerVitals : MonoBehaviour
{
    //public Slider staminaSlider;
    //public int staminaFallRate;
   // public int maxStamina;


    public Slider hydrationSlider;
    public int maxHydration;
    public int hydrationFallRate;


    void Start()
    {
        //staminaSlider.maxValue = maxStamina;
        //staminaSlider.value = maxStamina;
        
        hydrationSlider.maxValue = maxHydration;
        hydrationSlider.value = maxHydration;



    }

    void Update()
    {

        //Hydration
        if(hydrationSlider.value >= 0)
        {
            hydrationSlider.value -= Time.deltaTime * hydrationFallRate;
            Debug.Log("");
        }

        else if(hydrationSlider.value <= 0)
        {
            hydrationSlider.value = 0;
        }

        else if(hydrationSlider.value >= maxHydration)
        {
            hydrationSlider.value = maxHydration;
        }

        if(hydrationSlider.value == 0)
        {
            CharacterDeath();
            

            
        }
    }

    private void CharacterDeath()
    {
        Debug.Log("dead");
    }
}
