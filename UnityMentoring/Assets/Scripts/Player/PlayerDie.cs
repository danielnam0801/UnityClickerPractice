using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    CircleCollider2D playerCollider2d;
    EnemySpawnManager spawnManager;
    private void Awake()
    {
        playerCollider2d = GetComponent<CircleCollider2D>();
        spawnManager = FindObjectOfType<EnemySpawnManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.PlayerDie();
            Destroy(gameObject);
        }    
    }
}
