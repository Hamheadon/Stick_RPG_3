using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 _input;
    Rigidbody _rb;
    [SerializeField] float _moveSpeed; // game units per second at max speed
    [SerializeField] float _turnSpeed = 360; // degrees per second
    // turning radius is (_moveSpeed/2pi)/(_turnSpeed/360)

    private void Start()
    {
        _rb = GetComponent<Rigidbody>(); 
    }
    private void Update()
    {
        GatherInput(); // set the input direction
        Look(); // turn towards the correct direction
    }

    private void FixedUpdate()
    {
        Move(); // go forward
    }
    void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    void Look()
    {
        if (_input != Vector3.zero)
        {
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

            var skewedInput = matrix.MultiplyPoint3x4(_input);

            var relative = (transform.position + skewedInput) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
        }
    }

    void Move()
    {
        _rb.MovePosition(transform.position + (transform.forward * _input.magnitude) * _moveSpeed * Time.deltaTime);
    }
}
