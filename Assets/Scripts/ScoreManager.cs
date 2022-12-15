using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour // MonoBehaviour — это базовый класс, от которого по умолчанию наследуется каждый скрипт Unity
{
    private int player1Score = 0; // Счётчик очков первого игрока
    private int player2Score = 0; // Счётчик очков второго игрока

    public Text player1ScoreText; // Текстовый счётчик очков первого игрока
    public Text player2ScoreText; // Текстовый счётчик очков второго игрока

    public void Player1Goal() // При вызове увеличивает счёт первого игрока на одно очко
    {
        player1Score++;
        player1ScoreText.text = player1Score.ToString();
    }

    public void Player2Goal() // При вызове увеличивает счёт второго игрока на одно очко
    {
        player2Score++;
        player2ScoreText.text = player2Score.ToString();
    }
}