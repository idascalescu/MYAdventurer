using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthPointsBar : MonoBehaviour
{
    public static Slider healthPointsSlider;
    public Image fill;

    private void Start()
    {
        healthPointsSlider = GetComponent<Slider>();
        healthPointsSlider.value = 100.0f;
    }

    public void SetMaxHealthBT(float health)
    {
        healthPointsSlider.maxValue = health;
        healthPointsSlider.value = health;
    }

    public void SetHealthBT(float health)
    {
        healthPointsSlider.value = health;
    }
}
