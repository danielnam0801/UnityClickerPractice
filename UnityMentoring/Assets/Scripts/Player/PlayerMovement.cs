using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : AgentMovement
{
    public float speed = 3f;

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Move(new Vector2(x,y),speed);
    }
}
