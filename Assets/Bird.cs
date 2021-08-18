using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    [SerializeField] private ClickZone _clickZone;

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _rotateSpeed;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _clickZone.ONClicked += Jump;
    }

    private void Update()
    {
        Rotating();
    }

    private void Rotating()
    {
        transform.eulerAngles = new Vector3(0, 0, _rigidbody.velocity.y * _rotateSpeed);
    }

    private void Jump()
    {
        _rigidbody.velocity = Vector2.up * _jumpForce;
    }

    private void OnDestroy()
    {
        _clickZone.ONClicked -= Jump;
    }
}