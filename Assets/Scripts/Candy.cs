using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject GoalEffect;
    [SerializeField] Gradient graidnet;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
            Goal(collision.gameObject);
    }
    private void Goal(GameObject Goal)
    {
        Instantiate(GoalEffect, Goal.transform.position, Quaternion.identity);
        gameManager.SetActiveImages();
        Destroy(gameObject);
    }
    
}
