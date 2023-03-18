using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Elevator : MonoBehaviour
{
    [SerializeField] Transform[] points;
    [Range(0.001f, 10)] [SerializeField] float Speed;
    [Range(0.001f, 10)] [SerializeField] float SleepTime;

    public int index = 1;
    private bool IsCanMove = true;
    public bool Turn = true;
    private bool _did, _canGo;


    private void Update()
    {
        next();
        _did = true;
        _canGo = true;
    }

    private void next()
    {
        if (!Turn) return;
        if (_canGo)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, points[index].position, Speed * Time.deltaTime);
            //gameObject.transform.DOMove(points[index].position, Speed, false);
            _did = true;
            _canGo = false;
        }
        if(gameObject.transform.position == points[index].position)
        {
            if (_did)
            {
                if (index + 1 == 2)
                    index = 0;
                else
                    index++;
                StartCoroutine(Wait());
                Turn = false;
                _did = false;
            }
        }
    }


    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(SleepTime);
        Turn = true;
        _canGo = true;
    }
}
