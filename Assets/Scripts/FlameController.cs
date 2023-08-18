using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameController : MonoBehaviour
{
    [SerializeField]
    private float minThrust;

    [SerializeField]
    private float maxThrust = 3.0f;

    private float currentThrust;
    private float thrustInPercentOfMax;

    [SerializeField]
    private float changePerSecByInput;

    public event Action<float> EventThrustChanged = delegate { };
    
    private void ChangeThrust(float changeBy)
    {
        currentThrust = Mathf.Clamp(currentThrust + changeBy, minThrust, maxThrust);

        thrustInPercentOfMax = (currentThrust - minThrust) / (maxThrust - minThrust);

        EventThrustChanged(thrustInPercentOfMax);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            ChangeThrust(changePerSecByInput * Time.deltaTime);
        else if (Input.GetKey(KeyCode.Space))
            ChangeThrust(changePerSecByInput * Time.deltaTime);
    }
}
