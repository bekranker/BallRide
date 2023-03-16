using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    [Range(-100, 100)] [SerializeField] float Speed;
    void Update()
    {
        transform.Rotate(0,0, Speed * 10 * Time.deltaTime);
    }
}
