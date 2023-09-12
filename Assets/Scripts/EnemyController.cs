using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private int mSpeed;

    bool lookAt = false;

    public int speed;
    public float healtPoints;
    public float maxHealth;

    public Rigidbody rBody;

    [HideInInspector]
    public LevelOneBossHealthBar torpedoHB;

    void Start()
    {
        healtPoints = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        rBody = player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        LevelOneBossHealthBar.torpedoHP.value = healtPoints;

        if(FollowPlayer.found) 
        {
            lookAt = true;
        } 
        if(lookAt)
        {
            transform.LookAt(player.transform);
            Vector3 vel = rBody.velocity;
            if(!FollowPlayer.found && vel.x > -2 && vel.y< 2 && vel.z < 2)
            {
                rBody.AddForce(speed * Time.deltaTime * transform.forward);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Torpedo")
        {
            BossLvL1DMG(10.0f);
            Destroy(collision.gameObject);
            if (healtPoints <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void BossLvL1DMG(float damageAmount)
    {
        healtPoints -= damageAmount;
    }

    public void SomeFunction()
    {
        transform.LookAt(player.transform);
        Vector3 eulerAngles = transform.rotation.eulerAngles;
        eulerAngles.x = 0;
        eulerAngles.y = 0;
        eulerAngles.z = 0;
        transform.rotation = Quaternion.Euler(eulerAngles);

        rBody.AddRelativeForce(0, 0, mSpeed);
    }
}
