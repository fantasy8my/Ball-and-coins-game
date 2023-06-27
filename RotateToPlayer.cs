using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    private Transform _playerTransform;
    public Vector3 RightEuler;
    public Vector3 LeftEuler;
    public float RotationSpeed = 5;
    private Vector3 _targetEuler;

    private void Start()
    {
        //���� ������ � �����
        _playerTransform = FindObjectOfType<PlayerHealth>().transform;
    }
    private void Update()
    {
        //��������� ������ �� �����
        if (transform.position.x < _playerTransform.position.x)
        {
            //����������� ������
            _targetEuler = LeftEuler;
        }
        else
        {
            //����������� �������
            _targetEuler = RightEuler;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targetEuler), Time.deltaTime * RotationSpeed);
    }
}
