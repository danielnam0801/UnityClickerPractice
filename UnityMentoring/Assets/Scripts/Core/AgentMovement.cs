using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    protected Rigidbody2D rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 input, float speed)
    {
        rigidbody.velocity = input.normalized * speed;
    }
}
