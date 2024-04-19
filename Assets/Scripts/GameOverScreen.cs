using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public void GameOver()
    {
        gameOverText.text = "GAME OVER";
        gameObject.SetActive(true);
    }
    public void Win()
    {
        gameOverText.text = "WIN";
        gameObject.SetActive(true);
    }
}
