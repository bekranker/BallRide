using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[Range(0, 100)] [SerializeField] float Speed;
    //[Range(0, 100)] [SerializeField] float JumpValue;
    //[SerializeField] Rigidbody2D rb;
    //[SerializeField] LayerMask layerMask;
    //[SerializeField] float Min;
    //[SerializeField] float Max;
    //[SerializeField] GameManager manager;
    //[SerializeField] GameObject GroundEffect;

    //private float xInputs;
    //private float yInputs;
    //private bool isJump = false;
    //private bool grounded = false;




    //private void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //    manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    //}

    //private void Update()
    //{
    //    ProccressInputs();
    //    Jump();
    //    ClampVelocity();
    //}
    //private void FixedUpdate()
    //{
    //    Move();
    //}
    //private void ProccressInputs()
    //{
    //    xInputs = Input.GetAxisRaw("Horizontal");
    //}

    //private void Move()
    //{
    //    rb.AddForce(new Vector2(xInputs, 0) * Speed * 100 * Time.deltaTime);
    //}
    //private void Jump()
    //{
    //    if (!grounded) return;
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        rb.AddForce(Vector2.up * JumpValue, ForceMode2D.Impulse);
    //        grounded = false;
    //    }
    //}
    //private void ClampVelocity()
    //{
    //    Debug.Log(rb.velocity.magnitude.ToString());
    //    if (rb.velocity.magnitude >= Max)
    //    {
    //        var rbs = rb.velocity;
    //        rbs.x = Mathf.Clamp(rbs.x, Min, Max);
    //        rb.velocity = rbs;
    //    }
    //}
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Candy") || collision.gameObject.CompareTag("Elevator"))
    //    {
    //        grounded = true;
    //    }
    //    if (collision.gameObject.CompareTag("Goal"))
    //    {
    //        GetComponent<Collider2D>().enabled = false;
    //        GetComponent<SpriteRenderer>().enabled = false;
    //        rb.gravityScale = 0;
    //        manager.SetActiveImages();
    //    }
    //}
    [SerializeField, Range(0f, 100f)] private float _maxSpeed = 4f;
    [SerializeField, Range(0f, 100f)] private float _maxAcceleration = 35f;
    [SerializeField, Range(0f, 100f)] private float _maxAirAcceleration = 20f;

    private Vector2 _direction, _desiredVelocity, _velocity;
    private Rigidbody2D _body;
    private Ground _ground;

    private float _maxSpeedChange, _acceleration;
    private bool _onGround;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _ground = GetComponent<Ground>();
    }

    private void Update()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        _desiredVelocity = new Vector2(_direction.x, 0f) * Mathf.Max(_maxSpeed - _ground.Friction, 0f);
    }

    private void FixedUpdate()
    {
        _onGround = _ground.OnGround;
        _velocity = _body.velocity;

        _acceleration = _onGround ? _maxAcceleration : _maxAirAcceleration;
        _maxSpeedChange = _acceleration * Time.deltaTime;
        _velocity.x = Mathf.MoveTowards(_velocity.x, _desiredVelocity.x, _maxSpeedChange);

        _body.velocity = _velocity;
    }
}
