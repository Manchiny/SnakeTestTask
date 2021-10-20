using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    [SerializeField]
    private Transform _parentPartTransform;

    private Vector3 _targetPoint;

    private void Start()
    {
        _targetPoint = _parentPartTransform.position;
    }

    private void FixedUpdate()
    {
        transform.position = transform.position + (_targetPoint - transform.position) * 5f* Time.fixedDeltaTime;
        transform.LookAt(_targetPoint);

        if ((transform.position - _targetPoint).sqrMagnitude < 0.15f )
            _targetPoint = _parentPartTransform.position;
    }
}
