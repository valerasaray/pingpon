using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

public class Ball : MonoBehaviour // MonoBehaviour — это базовый класс, от которого по умолчанию наследуется каждый скрипт Unity
{
    public new Rigidbody2D rigidbody; // Создаём объект твёрдого тела
    public Vector2 direction; // Создаём объект вектора 2D, позицию мяча
    public float speed; // Скорость
    public float baseSpeed; // Начальная скорость
    public float coefficientSpeed; // Коэффициент скорости

    public ScoreManager scoreManager; // Счётчик

    public Vector2 startPos; // Создаём объект вектора 2D, начальную позицию мяча

    public int counter = 0; // Счётчик

    public Agent agent; // ML Agent

    void Start() // Запуск вызывается во фрейме, когда сценарий включен непосредственно перед первым вызовом любого из методов обновления.
    {
        startPos = this.transform.position; // Устанавливаем начальную позицию
        direction = new Vector2(Random.Range(0.5f, 1f), Random.Range(-0.3f, 0.3f)); // Устанавливаем направление полёта мяча
        speed = baseSpeed; // Устанавливаем скорость
    }

    void Update() //  Update вызывается перед визуализацией кадра, а также перед вычислением анимации.
    {
        rigidbody.velocity = direction.normalized * speed; // velocity - вектор скорости жесткого тела. Он представляет скорость изменения положения жесткого тела.
    }

    public void OnCollisionEnter2D(Collision2D collision) // Передается когда входящий коллайдер контактирует с коллайдером данного объекта (только 2D физика).
    {
        if (collision.gameObject.CompareTag("Player")) // Если касается объекта с тегом Player
        {
            counter = 0;
            direction.x = -direction.x; // инверсия направления по X
            speed = speed + coefficientSpeed;
        }

        if (collision.gameObject.CompareTag("Wall")) // Если касается объекта с тегом Wall
        {
            // Проверка на зацикленные отбития
            counter++;
            if (counter == 7) {
                this.transform.position = startPos; // перемещение на начальную позицию
                direction -= new Vector2(Random.Range(0.5f, 1f) + 10, Random.Range(0.5f, 1f) + 10); // Изменение направления
                counter = 0;
            }

            direction.y = -direction.y; // инверсия направления по Y
        }

        if  (collision.gameObject.name == "Right Border") // Если касается объекта с названием Right Border
        {
            counter = 0;
            scoreManager.Player1Goal(); // увеличение счётчика очков
            this.transform.position = startPos; // перемещение на начальную позицию
            direction += new Vector2(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f)); // Изменение направления
            direction.x = -direction.x; // инверсия направления по X
            speed = speed - coefficientSpeed;
        }

        if  (collision.gameObject.name == "Left Border") // Если касается объекта с названием Left Border
        {
            counter = 0;
            scoreManager.Player2Goal(); // увеличение счётчика очков
            this.transform.position = startPos; // перемещение на начальную позицию
            direction += new Vector2(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f)); // Изменение направления
            direction.x = -direction.x; // инверсия направления по X
            speed = speed - coefficientSpeed;
        }

        // Система вознаграждения и наказания

        // if (collision.gameObject.name == "Right_Player") // Если касается объекта с названием Right_Player
        // {
        //     // Debug.Log("+1 ball"); // Отладка
        //     agent.SetReward(+1f); // Установить +1 очко агенту
        //     agent.EndEpisode(); // Закончить эпизод
        // }

        // if (collision.gameObject.name == "Right Border") // Если касается объекта с названием Right Border
        // {
        //     // Debug.Log("-1 ball"); // Отладка
        //     agent.SetReward(-1f); // Установить -1 очко агенту
        //     agent.EndEpisode(); // Закончить эпизод
        // }

        // if (collision.gameObject.name == "Left_Player") // Если касается объекта с названием Left_Player
        // {
        //     // Debug.Log("+1 left ball"); // Отладка
        //     agent.SetReward(+1f); // Установить +1 очко агенту
        //     agent.EndEpisode(); // Закончить эпизод
        // }

        // if (collision.gameObject.name == "Left Border") // Если касается объекта с названием Left Border
        // {
        //     // Debug.Log("-1 left ball"); // Отладка
        //     agent.SetReward(-1f); // Установить -1 очко агенту
        //     agent.EndEpisode(); // Закончить эпизод
        // }
    }
}