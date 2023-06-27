using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnColision : MonoBehaviour
{
    public EnemyHealth EnemyHealth;
    public bool DieOnAnyCollision;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<BulletScript>())
            {
                EnemyHealth.TakeDamage(1);
            }
        }
        if (DieOnAnyCollision)
        {
            EnemyHealth.TakeDamage(1000);
        }
    }
}
