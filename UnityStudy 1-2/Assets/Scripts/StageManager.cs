using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    EnemyManager enemyManager;
    UIManager uiManager;

    [SerializeField] GameObject bossPrefab;
    public bool bossSpawn;
    public bool canSpawnBoss;

    private void Awake()
    {
        enemyManager = transform.parent.GetComponentInChildren<EnemyManager>();
        uiManager = transform.parent.GetComponentInChildren<UIManager>();
    }

    private void Update()
    {
        if(uiManager.currentStage % 10 == 0)
        {
            if (canSpawnBoss)
            {
                canSpawnBoss = false;
                enemyManager.SpawnEnemy(bossPrefab,enemyManager.spawnTransform);
            }
        }
    }

}
