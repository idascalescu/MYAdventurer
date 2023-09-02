using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthPointsBar : MonoBehaviour
{
    [SerializeField]
    public static Slider healthPointsSlider;
    public Image fill;

    private void Start()
    {
        healthPointsSlider = GetComponent<Slider>();
        healthPointsSlider.value = 100.0f;
    }

    public void SetMaxHealthPlayer(float health)
    {
        healthPointsSlider.maxValue = health;
        healthPointsSlider.value = health;
    }

    public void SetHealthPlayer(float health)
    {
        healthPointsSlider.value = health;
    }
}
