using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            Debug.Log("lalala");
        }

        if (collision.gameObject.tag == "Collectible")
        {
            Destroy(collision.gameObject);
        }
    }
}
