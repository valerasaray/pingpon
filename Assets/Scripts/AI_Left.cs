using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class AI_Left : Agent  // Класс Agent расширяет класс MonoBehaviour Unity. Agent нужен для ML Agents.
{
    //  SerializeField атрибут используется, когда вам нужно, чтобы ваша переменная была private, но также хотите, чтобы она отображалась в редакторе.
    [SerializeField] private Transform targetTransform; // Создаем объект для управления положением объекта.

    // override переопределяет метод наследуемого класса
    public override void CollectObservations(VectorSensor sensor) // Собирате наблюдения
    {
        sensor.AddObservation(transform.position); // Добавляем наблюдение о позиции ракетки
        sensor.AddObservation(targetTransform.position); // Добавляем наблюдение о позиции нашей цели, то есть мячика
    }

    public override void OnActionReceived(ActionBuffers actions) // Получает буфер с нашими действиями 
    {
        float moveY = actions.ContinuousActions[0]; // создаём переменную перемещения по Y

        float moveSpeed = 8f; // Скорость ракетки
        transform.position += new Vector3(0.0f, moveY, 0.0f) * Time.deltaTime * moveSpeed; // Изменим позицию ракетки
    }
}