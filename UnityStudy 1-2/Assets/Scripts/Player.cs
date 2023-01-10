using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject bullet;
    
    private GameManager gameManager;
    private EnemyManager enemyManager;
    private UIManager uiManager;
    private float attackSpeed;
    private Rigidbody2D rigid;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        enemyManager = FindObjectOfType<EnemyManager>();
        uiManager = FindObjectOfType<UIManager>();
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(Attack());
    }
    void Update()
    {
        attackSpeed =100/ (100 * Mathf.Sqrt(uiManager.currentStage));

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(h, v).normalized;
        rigid.velocity = dir * moveSpeed;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyManager.StopGame();
            uiManager.GameReStart();
            Destroy(gameObject);
        }
    }
    IEnumerator Attack()
    {
        while (true)
        {
            Instantiate(bullet,transform.position,Quaternion.identity);
            yield return new WaitForSeconds(attackSpeed);
        }
    }
}
