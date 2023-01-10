using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    UIManager uiManager;
    EnemyManager enemyManager;
    GameObject player;
    OutlineShader outlineShader;

    public BigInteger levelUpCost;
    public BigInteger power;

    public bool canAttack = true;
    public bool isClick = false;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        enemyManager = FindObjectOfType<EnemyManager>();
        player = GameObject.Find("Player");
        outlineShader = player.GetComponent<OutlineShader>();
    }
    void Update()
    {
        levelUpCost = (BigInteger)(50 * (Mathf.Pow(1.07f, uiManager.currentLevel - 1)));
        power = (BigInteger)((float)levelUpCost * 0.4f);
        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
        {
            enemyManager.SortEnemy();
            isClick = true;
            outlineShader.OnClick(isClick);
            canAttack = false;
            if(enemyManager.enemyList.Count != 0)
            {
                enemyManager.filterEnemyList[0].GetComponent<Enemy>().
                EnemyOnHit(power);
            }
            else
            {
                enemyManager.SpawnEnemy(enemyManager.enemyPrefab,enemyManager.spawnTransform);
            }
            StartCoroutine("AttackCool");
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isClick=false;
            outlineShader.OnClick(isClick);
        }
    }

    IEnumerator AttackCool()
    {
        yield return new WaitForSeconds(0.1f);
        canAttack = true;
    }
}
