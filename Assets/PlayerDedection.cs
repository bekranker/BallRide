using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDedection : MonoBehaviour
{
    GameManager _gameManager;
    Player _player;

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _player = GetComponent<Player>();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            Instantiate(_player.GroundEffect, collision.gameObject.transform.position, Quaternion.identity);
            _gameManager.SetActiveImages();
            gameObject.SetActive(false);
        }
    }
}
