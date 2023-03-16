using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject GoalEffect;
    [SerializeField] GameObject FallEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
            Goal(collision.gameObject);
        if (collision.gameObject.CompareTag("Ground"))
            Ground(collision.gameObject);
    }
    private void Goal(GameObject Goal)
    {
        Instantiate(GoalEffect, Goal.transform.position, Quaternion.identity);
        gameManager.SetActiveImages();
        Destroy(gameObject);
    }
    private void Ground(GameObject Ground)
    {
        if(GetComponent<Rigidbody2D>().velocity.y <= -1)
        Instantiate(FallEffect, new Vector2(transform.position.x, transform.position.y - (transform.localScale.y / 2)), Quaternion.identity);
    }
}
