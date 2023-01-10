using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private UnityEngine.Vector2 moveDir;
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rigid;
    Clicker clicker;

    public BigInteger damage { get; set; }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        clicker = FindObjectOfType<Clicker>();
        
    }
    private void Start()
    {
        rigid.velocity = moveDir * moveSpeed;
        damage = (BigInteger)((float)clicker.power * 2.5f);
    }
}
