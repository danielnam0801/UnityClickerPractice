using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : AgentMovement
{
    [SerializeField] float moveSpeed = 5f;
    private void Update()
    {
        Move(new Vector2(0,-1),moveSpeed);
    }
}
