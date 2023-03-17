using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpad : MonoBehaviour
{
    [Range(0.001f, 100)] [SerializeField] float Force;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Candy"))
        {
            Vector2 direction = collision.GetContact(0).normal;
            if (direction.y <= .01f)
            {
                Audio.PlayAudio("Jumpad", .5f, "General", "Sound");
                GetComponent<Animator>().SetTrigger("Stress");
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Force, ForceMode2D.Impulse);
            }
        }
    }
}
