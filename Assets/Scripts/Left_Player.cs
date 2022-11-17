using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left_Player : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public float speed;
    
    void Start()
    {
        
    }

    void Update()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction = Vector2.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction = Vector2.down;
        }
        rigidbody.velocity = direction * speed;
    }
}