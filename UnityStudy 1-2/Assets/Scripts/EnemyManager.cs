using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemyList = new List<Enemy>();
    public List<Enemy> filterEnemyList = new List<Enemy>();

    public int currentEnemyCnt = 0;
    public GameObject enemyPrefab;
    public Transform spawnTransform;
    [SerializeField] float spawnCooldownTime;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void Update()
    {
        
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            SpawnEnemy(enemyPrefab,spawnTransform);
            yield return new WaitForSeconds(spawnCooldownTime);
        }
    }

    public void SortEnemy()
    {
        filterEnemyList = new List<Enemy>();
        filterEnemyList = enemyList.OrderBy(n => Vector3.Distance(transform.position, n.transform.position)).ToList();
    }

    public void StopGame()
    {
        StopAllCoroutines();
        foreach (var item in enemyList)
        {
            Destroy(item);
        }
    }

    public void SpawnEnemy(GameObject enemyPrefab, Transform spawnTransform)
    {
        if (enemyList.Count <= 8)
        { 
            enemyList.Add(Instantiate(enemyPrefab, new Vector2(spawnTransform.position.x + Random.Range(-2.6f, 2.6f)
                , spawnTransform.position.y), Quaternion.identity).GetComponent<Enemy>());
        }
    }
}
