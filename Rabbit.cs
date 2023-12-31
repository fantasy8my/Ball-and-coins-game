using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{
    public float AttackPeriod = 7;
    public Animator Animator;
    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > AttackPeriod)
        {
            _timer = 0;
            Animator.SetTrigger("EnemySpotted");
        }
    }
}
