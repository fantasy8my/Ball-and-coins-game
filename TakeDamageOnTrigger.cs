using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    public EnemyHealth EnemyHealth;
    public bool DieOnAnyTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<BulletScript>())
            {
                EnemyHealth.TakeDamage(1);
            }
        }
        if (DieOnAnyTrigger)
        {
            if (other.isTrigger == false)
            {
                EnemyHealth.TakeDamage(1000);
            }
        }

    }
}
