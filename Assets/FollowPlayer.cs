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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        found = false;
    }
}
