using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour // MonoBehaviour — это базовый класс, от которого по умолчанию наследуется каждый скрипт Unity
{
    public void MoveToScene(int SceneID) // Функция для смены сцены
    {
        SceneManager.LoadScene(SceneID); // Загружает выбранную сцену
    }

    public void Quit() // Функция для выхда из игры
    {
        Application.Quit(); // Закрывает игру
    }
}
