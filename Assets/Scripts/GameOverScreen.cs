using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public Upgrade upgrade;
    public bool stopGame = false;
    public void GameOver()
    {
        gameOverText.text = "GAME OVER";
        gameObject.SetActive(true);
        stopGame = true;
    }
    public void Win()
    {
        gameOverText.text = "WIN";
        gameObject.SetActive(true);
        stopGame = true;
    }

    public void playAgain()
    {
        stopGame = false;
        upgrade.resetCurrency();
        gameObject.SetActive(false);
    }
}
