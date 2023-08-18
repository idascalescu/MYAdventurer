using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFlame : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _particleSystem;

    [SerializeField]
    private FlameController _flameController;

    [SerializeField]
    private float minStartSpeed;

    [SerializeField]
    private float maxStartSpeed;

    [SerializeField]
    private Vector3 minPosition;

    [SerializeField]
    private Vector3 maxPosition;

    private ParticleSystem.MainModule mainModule;

    private void OnEnable()
    {
        _flameController.EventThrustChanged += SetStartSpeed;
        if(minPosition != maxPosition) 
        {
            _flameController.EventThrustChanged += SetPosition;
        }

        mainModule = _particleSystem.main;
    }

    private void SetStartSpeed(float thrustInPercent)
    {
        float speed = thrustInPercent * minStartSpeed + (1f - thrustInPercent) * minStartSpeed;
        mainModule.startSpeed = speed;
    }

    private void SetPosition(float thrustInPercent)
    {
        Vector3 pos = thrustInPercent * maxPosition + (1f - thrustInPercent) * minPosition;
        _particleSystem.transform.localPosition = pos;
    }

    private void OnDisable()
    {
        _flameController.EventThrustChanged -= SetStartSpeed;

        if (minPosition != maxPosition)
        {
            _flameController.EventThrustChanged -= SetPosition;
        }
    }
}
