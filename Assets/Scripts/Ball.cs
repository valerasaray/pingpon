using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

public class Ball : MonoBehaviour // MonoBehaviour — это базовый класс, от которого по умолчанию наследуется каждый скрипт Unity
{
    public new Rigidbody2D rigidbody;
    public Vector2 direction;
    public float speed;
    public float baseSpeed;
    public float coefficientSpeed;

    public ScoreManager scoreManager;

    public Vector2 startPos;

    public int counter = 0;

    public Agent agent;

    void Start()
    {
        startPos = this.transform.position;
        direction = new Vector2(Random.Range(0.5f, 1f), Random.Range(-0.3f, 0.3f));
        speed = baseSpeed;
    }

    void Update()
    {
        rigidbody.velocity = direction.normalized * speed;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            counter = 0;
            direction.x = -direction.x;
            speed = speed + coefficientSpeed;
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            counter++;
            if (counter == 7) {
                this.transform.position = startPos;
                direction -= new Vector2(Random.Range(0.5f, 1f) + 10, Random.Range(0.5f, 1f) + 10);
                counter = 0;
            }

            direction.y = -direction.y;
        }

        if  (collision.gameObject.name == "Right Border")
        {
            counter = 0;
            scoreManager.Player1Goal();
            this.transform.position = startPos;
            direction += new Vector2(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
            direction.x = -direction.x;
            speed = speed - coefficientSpeed;
        }

        if  (collision.gameObject.name == "Left Border")
        {
            counter = 0;
            scoreManager.Player2Goal();
            this.transform.position = startPos;
            direction += new Vector2(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
            direction.x = -direction.x;
            speed = speed - coefficientSpeed;
        }

        // if (collision.gameObject.name == "Right_Player")
        // {
        //     Debug.Log("+1 ball");
        //     agent.SetReward(+1f);
        //     agent.EndEpisode();
        // }

        // if (collision.gameObject.name == "Right Border")
        // {
        //     Debug.Log("-1 ball");
        //     agent.SetReward(-1f);
        //     agent.EndEpisode();
        // }

        // if (collision.gameObject.name == "Left_Player")
        // {
        //     Debug.Log("+1 left ball");
        //     agent.SetReward(+1f);
        //     agent.EndEpisode();
        // }

        // if (collision.gameObject.name == "Left Border")
        // {
        //     Debug.Log("-1 left ball");
        //     agent.SetReward(-1f);
        //     agent.EndEpisode();
        // }
    }
}