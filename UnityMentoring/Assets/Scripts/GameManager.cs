using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    EnemySpawnManager spawnManager;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        spawnManager = FindObjectOfType<EnemySpawnManager>();
    }

    public void PlayerDie()
    {
        StartCoroutine("New");
        spawnManager.ClearEnemy();
    }
    IEnumerator New()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Main");
    }

}
