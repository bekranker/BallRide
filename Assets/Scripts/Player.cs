using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(0, 100)] [SerializeField] float Speed;
    [Range(0, 100)] [SerializeField] float JumpValue;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float Min;
    [SerializeField] float Max;
    [SerializeField] GameManager manager;
    [SerializeField] GameObject GroundEffect;

    private float xInputs;
    private float yInputs;
    private bool isJump = false;
    private bool grounded = false;




    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        ProccressInputs();
        Jump();
        ClampVelocity();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void ProccressInputs()
    {
        xInputs = Input.GetAxisRaw("Horizontal");
    }

    private void Move()
    {
        rb.AddForce(new Vector2(xInputs, 0) * Speed * 100 * Time.deltaTime);
    }
    private void Jump()
    {
        if (!grounded) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * JumpValue, ForceMode2D.Impulse);
            grounded = false;
        }
    }
    private void ClampVelocity()
    {
        Debug.Log(rb.velocity.magnitude.ToString());
        if (rb.velocity.magnitude >= Max)
        {
            var rbs = rb.velocity;
            rbs.x = Mathf.Clamp(rbs.x, Min, Max);
            rb.velocity = rbs;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Candy") || collision.gameObject.CompareTag("Elevator"))
        {
            grounded = true;
        }
        if (collision.gameObject.CompareTag("Goal"))
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            rb.gravityScale = 0;
            manager.SetActiveImages();
        }
    }
}
