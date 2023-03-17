using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ElevatorDedection : MonoBehaviour
{
    [SerializeField] Vector2 Size;
    [SerializeField] LayerMask mask;


    Collider2D[] balls;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, Size);
    }


    private void FixedUpdate()
    {

        if(Physics2D.OverlapBox(transform.position, Size, 0, mask))
        {
            balls = Physics2D.OverlapBoxAll(transform.position, Size, 0, mask);

            foreach (Collider2D ball in balls)
            {
                ball.transform.SetParent(gameObject.transform);
            }
        }
        else
        {
            foreach (Collider2D ball in balls)
            {
                ball.transform.SetParent(null);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.transform.SetParent(this.gameObject.transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.transform.SetParent(null);
    }
}
