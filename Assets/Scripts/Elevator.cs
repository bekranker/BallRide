using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] Transform[] points;
    [Range(0.001f, 10)] [SerializeField] float Speed;
    [Range(0.001f, 10)] [SerializeField] float SleepTime;

    public int index = 1;
    private bool IsCanMove = true;
    public bool Turn = false;

    private void Update()
    {
        next();
        Previous();
    }

    private void next()
    {
        if (Turn) return;
        if (IsOnSeat(transform.position, points[index].position))
        {
            if (index + 1 == points.Length)
                Turn = true;
            else
                index++;
            StartCoroutine(Wait());
        }
        if (IsCanMove)
        {
            StartCoroutine(MoveFromTo(transform.position, points[index].position, Speed, transform));
            IsCanMove = false;
        }
    }


    private void Previous()
    {
        if (!Turn) return;
        if (IsOnSeat(transform.position, points[index].position))
        {
            if (index - 1 == 0)
            {
                index = 0;
                Turn = false;
            }
            else
                index--;
            StartCoroutine(Wait());
        }
        if (IsCanMove)
        {
            StartCoroutine(MoveFromTo(transform.position, points[index].position, Speed, transform));
            IsCanMove = false;
        }
    }


    private bool IsOnSeat(Vector2 From, Vector2 To)
    {
        if (From == To) return true;
        else return false;
    }


    IEnumerator MoveFromTo(Vector3 from, Vector3 to, float speed, Transform tra)
    {
        var t = 0f;

        while (t < 1f)
        {
            t += speed * Time.deltaTime;
            tra.position = Vector3.Lerp(from, to, t);
            yield return null;
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(SleepTime);
        IsCanMove = true;
    }
}
