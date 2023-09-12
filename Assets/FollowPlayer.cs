using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    static public bool found = false;
 
    private void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            found = true;
            ABehaviorTree.speed = 0.0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        found = false;
        ABehaviorTree.speed = 2.0f;
    }
}
