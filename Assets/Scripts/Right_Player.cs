using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_Player : MonoBehaviour // MonoBehaviour — это базовый класс, от которого по умолчанию наследуется каждый скрипт Unity
{
    public new Rigidbody2D rigidbody; // Создаём объект твёрдого тела
    public float speed;
    
    void Start()
    {
        
    }

    void Update() //  Update вызывается перед визуализацией кадра, а также перед вычислением анимации.
    {
        Vector2 direction = Vector2.zero; // Создаём переменную направление типа Vector2

        if (Input.GetKey(KeyCode.UpArrow)) // При нажатии кнопки "Вверх" объект Right_Player двигается вверх
        {
            direction = Vector2.up;
        }

        if (Input.GetKey(KeyCode.DownArrow)) // При нажатии кнопки "Вниз" объект Right_Player двигается вниз
        {
            direction = Vector2.down;
        }
        rigidbody.velocity = direction * speed; // velocity - вектор скорости жесткого тела. Он представляет скорость изменения положения жесткого тела.
    }
}