using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerFuelBar : MonoBehaviour
{
    public static Slider fuelSlider;
    public Image fill;

    private void Start()
    {
        fuelSlider = GetComponent<Slider>();
        fuelSlider.value = 100.0f;
    }

    public void SetMaxHealthBT(float health)
    {
        fuelSlider.maxValue = health;
        fuelSlider.value = health;
    }

    public void SetHealthBT(float health)
    {
        fuelSlider.value = health;
    }
}
