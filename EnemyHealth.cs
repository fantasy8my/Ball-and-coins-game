using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public int Health = 1;
    public UnityEvent EventsOnDamage;
    public UnityEvent EventsOnDie;

    public void TakeDamage(int DamageValue)
    {
        Health -= DamageValue;
        EventsOnDamage.Invoke();
        if (Health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
        EventsOnDie.Invoke();
    }
}
