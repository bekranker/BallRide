using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [SerializeField] GameObject Effect;
    
    
    public Transform To;
    
    
    private Vector3 startSize;
    private Queue<Vector2> rbs = new Queue<Vector2>();





    private void Start()
    {
        startSize = transform.localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Candy"))
        {
            StartCoroutine(StartEffect());
            rbs.Enqueue(collision.gameObject.GetComponent<Rigidbody2D>().velocity);
            StartCoroutine(Wait(collision.gameObject));
        }

    }

    IEnumerator Wait(GameObject _object)
    {
        _object.GetComponent<SpriteRenderer>().enabled = false;
        _object.GetComponent<Collider2D>().enabled = false;
        _object.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Instantiate(Effect, transform.position, Quaternion.identity);
        Audio.PlayAudio("Portal", .15f, "General", "Sound");
        yield return new WaitForSecondsRealtime(.25f);
        Audio.PlayAudio("Portal", .15f, "General", "Sound");
        _object.gameObject.transform.position = To.position;
        StartCoroutine(EndEffect());
        Instantiate(Effect, To.transform.position, Quaternion.identity);
        _object.GetComponent<SpriteRenderer>().enabled = true;
        _object.GetComponent<Collider2D>().enabled = true;
        Vector2 a = rbs.Dequeue();
        _object.GetComponent<Rigidbody2D>().velocity = a;
    }

    IEnumerator StartEffect()
    {
        transform.localScale /= 1.5f;
        yield return new WaitForSecondsRealtime(.05f);
        transform.localScale = startSize;
    }
    IEnumerator EndEffect()
    {
        To.transform.localScale /= 1.5f;
        yield return new WaitForSecondsRealtime(.05f);
        To.transform.localScale = startSize;
    }
}
