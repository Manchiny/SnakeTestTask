using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    private Camera _camera;
    private Transform _transform;
    private Vector3 _targetPoint;
    private float _speed = 0.4f;

    RaycastHit _hit;
    private void Awake()
    {
        _transform = transform;
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _hit = CastFromCursor();

            if (_hit.transform != null)
            {

                if (_hit.transform.tag == ("Terrain"))
                {
                    _targetPoint = new Vector3(_hit.point.x, transform.position.y, _hit.point.z);
                }
            }
        }

        if (_targetPoint != null)
            MoveTo();
    }

    private RaycastHit CastFromCursor()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        return hit;
    }

    private void MoveTo()
    {
        if(Mathf.Abs(transform.position.x - _targetPoint.x) >= 0.2f || Mathf.Abs(transform.position.z - _targetPoint.z) >= 0.2f)
            transform.Translate(_targetPoint * _speed * Time.fixedDeltaTime);
    }
}
