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

        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            playerObject.transform.position = new Vector2(0, 0);
        }
        else
        {
            Debug.LogError("Player not found. Make sure the player has the correct tag assigned.");
        }
        //GameObject enemyObject = GameObject.FindWithTag("Enemy");
/*
        while (enemyObject.activeSelf)
        {
            Destroy(enemyObject);
        }
*/
        gameObject.SetActive(false);

    }
}
