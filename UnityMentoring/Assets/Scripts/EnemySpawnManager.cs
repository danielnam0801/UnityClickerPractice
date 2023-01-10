using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawnManager : MonoBehaviour
{
    public Vector2 maxSpawnPosition;
    public Vector2 minSpawnPosition;

    public Vector2 spawnPosition;

    public float spawnDelayTime = 0.5f;

    public bool isSpawning = false;
    public bool canSpawn = true;

    [SerializeField] GameObject enemy;

    private List<GameObject> activeEnemies = new List<GameObject>();

    private void Start()
    {
        spawnPosition.y = transform.position.y;    
    }

    public void Update()
    {
        if(activeEnemies.Count > 5)
        {
            canSpawn = false;
        }

        if(activeEnemies.Count == 0)
        {
            SpawningEnemy();
        }

        if (!isSpawning && canSpawn)
        {
            RandomSpawningPoint();
            SpawningEnemy();
            isSpawning = true;
        }
    }
    public void ClearEnemy()
    {
        foreach(GameObject enemy in activeEnemies)
        {
            Destroy(enemy);
        }
    }

    public void EnemyDie()
    {
        UIManager.moneyCnt = (System.Numerics.BigInteger)(10 * Mathf.Pow(1.06f, 10) - Mathf.Pow(1.06f, 10+StageManager.stageLevel));
        
    }

    private void SpawningEnemy()
    {
        activeEnemies.Add(Instantiate(enemy, spawnPosition, Quaternion.identity));
    }

    private void RandomSpawningPoint()
    {
        float x = UnityEngine.Random.Range(minSpawnPosition.x, maxSpawnPosition.x);
        spawnDelayTime = UnityEngine.Random.Range(spawnDelayTime-0.1f, spawnDelayTime+0.1f);
        spawnPosition.x = x;

        StartCoroutine("WaitSpawnTime",spawnDelayTime);
    }

    IEnumerator WaitSpawnTime(float spawnTime)
    {
        yield return new WaitForSeconds(spawnTime);
        isSpawning=false;
    }
}
