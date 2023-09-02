using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float healtPoints;
    public float maxHealth;

    [HideInInspector]
    public TorpedoHB torpedoHB;

    void Start()
    {
        healtPoints = maxHealth;
        
    }

    void Update()
    {
        TorpedoHB.torpedoHP.value = healtPoints;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Torpedo")
        {
            TorpedoTakesDamage(10.0f);
            Destroy(collision.gameObject);
            if (healtPoints <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void TorpedoTakesDamage(float damageAmount)
    {
        healtPoints -= damageAmount;
    }
}
