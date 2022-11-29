using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private CharacterController _characterController;
    private float _gravity = -9.8f;
    private Vector3 _velocity;
    private bool _isGrounded;
    private float groundDistance = 0.4f;

    public LayerMask groundMask;
    public Transform groundPos;
    public float speed = 12;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        _isGrounded = Physics.CheckSphere(groundPos.position, groundDistance, groundMask);
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 dir = transform.right * hor + transform.forward * ver;
        _characterController.Move(dir * speed * Time.deltaTime);

        _velocity.y += _gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }
}
