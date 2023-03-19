using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jump : MonoBehaviour
{
    private Rigidbody2D _body;
    private Ground _ground;
    private Vector2 _velocity;

    [SerializeField,Range(1, 100)] float _jumpSpeed;

    private bool _desiredJump, _onGround;


    void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _ground = GetComponent<Ground>();

    }

    void Update()
    {
        _desiredJump |= Input.GetButtonDown("Jump");
    }

    private void FixedUpdate()
    {
        _onGround = _ground.OnGround;
        _velocity = _body.velocity;

        if (_desiredJump)
        {
            _desiredJump = false;
            JumpAction();
        }

    }
    private void JumpAction()
    {
        if (_onGround)
        {
            _body.AddForce(_jumpSpeed * Vector2.up * 20);
        }
    }
}
