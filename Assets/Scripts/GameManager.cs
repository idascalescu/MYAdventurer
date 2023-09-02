using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                Debug.Log("Null GM");

            return instance;
        }
    }

    public bool GetTheFlame { get; set; }
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Cursor.visible=true;
        }
        else
            Cursor.visible=false;
    }
}
