using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public int cntKill = 0;
    EnemySpawnManager spawnManager;
    public int damage = 1;

    private void Awake()
    {
        spawnManager = FindObjectOfType<EnemySpawnManager>();
        damage = 
    }
    public void Update()
    {
        if(StageManager.enemykill >= 10)
        {
            StageManager.enemykill = 0;
            StageManager.stageLevel++;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (this.CompareTag("PlayerBullet"))
            {
                StageManager.enemykill++;
                spawnManager.EnemyDie();
                Destroy(collision.gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
