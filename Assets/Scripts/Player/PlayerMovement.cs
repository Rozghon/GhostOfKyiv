using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _turnSpeed = 5f;
    [SerializeField] private Joystick _joystick;

    private Vector2 _movementVector;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _joystick = GameObject.FindGameObjectWithTag("JoyStick").GetComponent<Joystick>();
    }

    private void Update()
    {
        //_movementVector.x = Input.GetAxisRaw("Horizontal");
        //_movementVector.y = Input.GetAxisRaw("Vertical");

        _movementVector = _joystick.Direction;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * _speed * Time.fixedDeltaTime);

        float _angle = Mathf.Atan2(_movementVector.y, _movementVector.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, _angle), _turnSpeed);
    }

    public void UpSpeed(float _value)
    {
        _speed += _value;
    }

    public void SetSpeed(float _value)
    {
        _speed = _value;
    }
}