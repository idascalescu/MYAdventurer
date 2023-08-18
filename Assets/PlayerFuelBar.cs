using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerFuelBar : MonoBehaviour
{
    public static Slider btSlider;
    public Image fill;

    private void Start()
    {
        btSlider = GetComponent<Slider>();
        btSlider.value = 100.0f;
    }

    public void SetMaxHealthBT(float health)
    {
        btSlider.maxValue = health;
        btSlider.value = health;
    }

    public void SetHealthBT(float health)
    {
        btSlider.value = health;
    }
}
