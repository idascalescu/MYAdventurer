using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : UnityEngine.MonoBehaviour
{
    private GameObject myCamera;
    void Start()
    {
        myCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        transform.rotation = (myCamera.transform.rotation);
    }
}