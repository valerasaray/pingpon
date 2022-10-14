using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_Player : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float speed;
    
    void Start()
    {
        
    }

    void Update()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = Vector2.up;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = Vector2.down;
        }
        rigidbody.velocity = direction * speed;
    }
}
