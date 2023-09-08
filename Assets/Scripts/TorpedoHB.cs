using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class TorpedoHB : MonoBehaviour
{ 
    public static Slider torpedoHP;
    public Image fill;

    private void Start()
    {
        torpedoHP = GetComponent<Slider>();
        torpedoHP.value = 300.0f;
    }

    public void SetMaxHealthTorpedo(float health)
    {
        torpedoHP.maxValue = health;
        torpedoHP.value = health;
    }

    public void SetHealthTorpedo(float health)
    {
        torpedoHP.value = health;
    }
}