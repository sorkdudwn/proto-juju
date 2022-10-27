using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_LYJ : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] public float _speed = 5f;
    [SerializeField] public float _turnSpeed = 360f;
    private Vector3 _input;

    void Update()
    {
        GatherInput();
        Look();
    }

    void FixedUpdate()
    {
        _rb.MovePosition(transform.position + (transform.forward * _input.magnitude) * _speed * Time.deltaTime);
    }

    void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    void Look()
    {
        if(_input != Vector3.zero)
        {
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

            var skewedInput = matrix.MultiplyPoint3x4(_input);

            var relative = (transform.position + skewedInput) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
        }
    }

}
