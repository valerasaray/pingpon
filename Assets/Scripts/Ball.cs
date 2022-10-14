using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public Vector2 direction;
    public float speed;
    public float baseSpeed;
    public float coefficientSpeed;

    public ScoreManager scoreManager;

    public Vector2 startPos;

    void Start()
    {
        startPos = this.transform.position;
        direction = new Vector2(Random.Range(-0.95f, 0.95f), Random.Range(-0.95f, 0.95f));
        speed = baseSpeed;
    }

    void Update()
    {
        rigidbody.velocity = direction.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            direction.x = -direction.x;
            speed = speed + coefficientSpeed;
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            direction.y = -direction.y;
        }

        if  (collision.gameObject.name == "Right Border")
        {
            scoreManager.Player1Goal();
            this.transform.position = startPos;
            direction.x = -direction.x;
            speed = speed - coefficientSpeed;
        }

        if  (collision.gameObject.name == "Left Border")
        {
            scoreManager.Player2Goal();
            this.transform.position = startPos;
            direction.x = -direction.x;
            speed = speed - coefficientSpeed;
        }
    }
}
