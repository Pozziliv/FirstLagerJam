using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _sensivity = 5f;
    [SerializeField] private float _maxHeadY = 40f;
    [SerializeField] private float _minHeadY = -40f;

    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed = 3f;

    private Vector3 _direction;
    private float _horizontal, _vertical;
    private Rigidbody _rb;
    private float _rotationY;
    private Transform _camera;
    private Transform _transform;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _transform = transform;
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
        _camera = Camera.main.transform;
    }

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        if (_horizontal != 0 || _vertical != 0)
            _animator.SetInteger("legs", 1);
        else
            _animator.SetInteger("legs", 5);

        _direction = new Vector3(_horizontal, 0, _vertical).normalized;
        _direction = _camera.TransformDirection(_direction);
        _direction = new Vector3(_direction.x, 0, _direction.z).normalized;
    }

    private void FixedUpdate()
    {
        _rb.velocity = _direction * _speed;
        _rotationY += Input.GetAxis("Mouse Y") * _sensivity;
        _rotationY = Mathf.Clamp(_rotationY, _minHeadY, _maxHeadY);
        float rotationX = _transform.eulerAngles.y + Input.GetAxis("Mouse X") * _sensivity;
        _transform.eulerAngles = new Vector3(0, rotationX, 0);
        _camera.localEulerAngles = new Vector3(-_rotationY, -90, 0);
    }
}
