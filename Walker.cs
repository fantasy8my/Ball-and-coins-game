using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right
}

public class Walker : MonoBehaviour
{
    public Transform LeftTarget;
    public Transform RightTarget;
    public Transform RayStart;

    public float Speed = 2;

    public float StopTime = 1f;
    private bool _isStopped;

    public UnityEvent EventOnLeftTarget;
    public UnityEvent EventOnRightTarget;

    private void Start()
    {
        LeftTarget.transform.parent = null;
        RightTarget.transform.parent = null;
    }

    public Direction CurrentDirection;

    private void Update()
    {
        if (_isStopped == true)
        {
            return;
        }

        if (CurrentDirection == Direction.Left)
        {
            transform.position -= new Vector3(Time.deltaTime * Speed, 0f, 0f);
            if (transform.position.x < LeftTarget.position.x)
            {
                CurrentDirection = Direction.Right;
                _isStopped = true;
                Invoke("ContinueWalk", StopTime);
                EventOnLeftTarget.Invoke();
            }
        }
        if (CurrentDirection == Direction.Right)
        {
            transform.position += new Vector3(Time.deltaTime * Speed, 0f, 0f);
            if (transform.position.x > RightTarget.position.x)
            {
                CurrentDirection = Direction.Left;
                _isStopped = true;
                Invoke("ContinueWalk", StopTime);
                EventOnRightTarget.Invoke();
            }
        }
        RaycastHit hit;
        if (Physics.Raycast(RayStart.position, Vector3.down, out hit))
        {
            transform.position = hit.point;
        }
    }
    
    void ContinueWalk()
    {
        _isStopped = false;
    }
}
