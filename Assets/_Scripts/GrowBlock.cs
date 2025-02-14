using UnityEngine;
using UnityEngine.InputSystem;

public class GrowBlock : MonoBehaviour
{   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public enum GrowthStage
    {
        barren,
        ploughed,
        planted,
        growing1,
        growing2,
        ripe
    }

    public GrowthStage currentStage;

    public SpriteRenderer theSR;
    public Sprite soilTilled, soilWatered;
    public bool isWatered;
    void Start()
    {
        
        
    }

    // Update is called once per frame

  
    void Update()
    {
       /* if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            AdvanceStage();
            SetSoilSprite();
        } 
       */


    }
    public void AdvanceStage()
    {
        currentStage = currentStage + 1;
        if((int)currentStage >= 6)
        {
            currentStage= GrowthStage.barren;
        }
    }

    public void SetSoilSprite()
    {
        if(currentStage == GrowthStage.barren)
        {
            theSR.sprite = null;
        }
        else
        {
            if (isWatered) 
            {
                theSR.sprite= soilWatered;

            }
            else
            {
                theSR.sprite= soilTilled;
            }
        }
    }

     public void PloughSoil()
    {
        if(currentStage== GrowthStage.barren)
        {
            currentStage =GrowthStage.ploughed;
            SetSoilSprite();
        }
    }

    public void WaterSoil()
    {
        isWatered = true;
        SetSoilSprite();
    }

}
