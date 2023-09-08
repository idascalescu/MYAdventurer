using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTorpeedos : MonoBehaviour
{
    public Vector3 minPos;
    public Vector3 maxPos;

    public GameObject prefab;

    Vector3 vector;

    private void Awake()
    {
        Vector3 randomPos = new Vector3(
        Random.Range(minPos.x, maxPos.x),
        Random.Range(minPos.y, maxPos.y),
        Random.Range(minPos.z, maxPos.z));

        transform.position = randomPos;
    }

    void Start()
    {
        for(int i = 0; i < 1; i++) 
        {
            Instantiate(prefab, vector, Quaternion.identity);
        }   
    }
}
