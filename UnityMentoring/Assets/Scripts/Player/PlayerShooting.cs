using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    public float attackCool = 1f;
    public bool isAttack;

    public float shootingPower = 5f;
    
    private void Update()
    {
        attackCool = 100/(Mathf.Sqrt(StageManager.stageLevel) * 100);
        if (!isAttack)
        {
            isAttack = true;
            StartCoroutine(WaitAttackCoolTime());
            GameObject PlayerBullet = Instantiate(bullet, transform.position, Quaternion.Euler(0,0,90));
            PlayerBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0,shootingPower);
        }
       
    }

    IEnumerator WaitAttackCoolTime()
    {
        yield return new WaitForSeconds(attackCool);
        isAttack = false;
    }
}
