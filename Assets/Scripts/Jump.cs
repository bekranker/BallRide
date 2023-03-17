using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jump : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] private float _jumpHeight = 3f;
    [SerializeField, Range(0, 5)] private int _maxAirJumps = 0;
    [SerializeField, Range(0f, 5f)] private float _downwardMovementMultiplier = 3f;
    [SerializeField, Range(0f, 5f)] private float _upwardMovementMultiplier = 1.7f;

    private Rigidbody2D _body;
    private Ground _ground;
    private Vector2 _velocity;

    [SerializeField,Range(1, 100)] float _jumpSpeed;

    private bool _desiredJump, _onGround;


    // Start is called before the first frame update
    void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _ground = GetComponent<Ground>();

    }

    // Update is called once per frame
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

        //if (_body.velocity.y > 0)
        //{
        //    _body.gravityScale = _upwardMovementMultiplier;
        //}
        //else if (_body.velocity.y < 0)
        //{
        //    _body.gravityScale = _downwardMovementMultiplier;
        //}
        //else if (_body.velocity.y == 0)
        //{
        //    _body.gravityScale = _defaultGravityScale;
        //}

        //_body.velocity = _velocity;
    }
    private void JumpAction()
    {
        if (_onGround)
        {
            _body.AddForce(_jumpSpeed * Vector2.up * 20);
        }
    }
}
