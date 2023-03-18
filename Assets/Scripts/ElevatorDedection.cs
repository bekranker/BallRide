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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        collision.gameObject.transform.SetParent(gameObject.transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.transform.SetParent(null);
    }
}
