using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController1 : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [Range(0, 3)]
    public float bonesDistance;

    [SerializeField]
    private float _speed = 1f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = transform.forward * _speed;
    }
    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0f)
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * 2f, 0);
            _rigidbody.velocity = transform.forward * _speed;
        }
    }

}
