using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField]
    private float projectileLifeTime;

    public GameObject projectile;
    private float launchVelocity = 690.0f;
    private float offSet = 300.0f;

    private Vector3 direction;
    private Vector3 startingPosition;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject ball = Instantiate(projectile, 
                transform.position, 
                transform.rotation);
            ball.GetComponent<Rigidbody>().
                AddRelativeForce
                (new Vector3(launchVelocity, 
                offSet, 0.0f));
        }
    }

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
        startingPosition = transform.position;
    }
}

