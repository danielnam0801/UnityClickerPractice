using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] Slider hpSlider;
    public float speed;
    [SerializeField] UnityEngine.Vector2 moveDir;
    private Rigidbody2D rigid;
    UIManager uiManager;
    EnemyManager enemyManager;
    GameManager gameManager;
  
    public BigInteger hp = 0;
    public BigInteger maxHP = 0;
    public bool isDead = false;
    public bool isBoss = false;

    public SpriteRenderer spriteRenderer;
    UnityEvent EnemyHitEvent;
    private bool isColorChange = false;

    void Start()
    {
        speed = Random.Range(3f,5f);
        spriteRenderer = GameObject.Find("BackGround").GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
        enemyManager = FindObjectOfType<EnemyManager>();
        uiManager = FindObjectOfType<UIManager>();
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = moveDir * speed;

        if (!isBoss)
            maxHP = (BigInteger)((Random.Range(10,21)/10 * 2) * (10 * ((Mathf.Pow(1.06f, 10) - Mathf.Pow(1.06f, 10 + uiManager.currentStage)) / (1 - 1.06f))));
        else
            maxHP = 20 * (BigInteger)(10 * ((Mathf.Pow(1.06f, 10) - Mathf.Pow(1.06f, 10 + uiManager.currentStage)) / (1 - 1.06f)));
        hp = maxHP;
    }
    private void Update()
    {
        hpSlider.transform.position = Camera.main.WorldToScreenPoint(transform.position + new UnityEngine.Vector3(0, -0.7f,0));
        if (hp <= 0)
        {
            isDead = true;
            Die();
        }
        hpSlider.value = ((float)hp / (float)maxHP);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DestroyZone"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            EnemyOnHit(collision.GetComponent<Bullet>().damage);
            Destroy(collision.gameObject);
        }
    }

    public void EnemyOnHit(BigInteger damage)
    {
        if (isDead) return;
        
        EnemyHitEvent?.Invoke();
        hp -= damage;
    }

    public void Die()
    {
        if (!isBoss)
        {
            uiManager.goldAmount += (BigInteger)(10 * ((Mathf.Pow(1.06f, 10) - Mathf.Pow(1.06f, 10 + uiManager.currentStage)) / (1 - 1.06f)));
            uiManager.currentEnemyDie++;
            enemyManager.enemyList.Remove(this);
            Destroy(gameObject);
        }
        else
        {
            uiManager.goldAmount += 10 * (BigInteger)(10 * ((Mathf.Pow(1.06f, 10) - Mathf.Pow(1.06f, 10 + uiManager.currentStage)) / (1 - 1.06f)));
            spriteRenderer.color = RandomColor();
        }
        StartCoroutine("isEnd");
    }

    private Color RandomColor()
    {
        Color newColor = new Color();
        newColor.r = Random.Range(0, 255);
        newColor.b = Random.Range(0, 255);
        newColor.g = Random.Range(0, 255);
        newColor.a = Random.Range(100, 150);
        isColorChange = true;
        return newColor;
    }

    IEnumerator isEnd()
    {
        yield return new WaitUntil(() => isColorChange);
        uiManager.currentEnemyDie++;
        enemyManager.enemyList.Remove(this);
        Destroy(gameObject);
    }
}
