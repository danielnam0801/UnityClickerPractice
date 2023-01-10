using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    EnemyManager enemyManager;
    
    private void Awake()
    {
        enemyManager = FindObjectOfType<EnemyManager>();    
    }
}
