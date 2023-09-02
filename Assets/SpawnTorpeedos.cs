using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTorpeedos : MonoBehaviour
{
    public GameObject prefab;

    Vector3 vector = new Vector3 (0, 0, 0); 
    void Start()
    {
        Instantiate(prefab, vector, Quaternion.identity);
    }
}
