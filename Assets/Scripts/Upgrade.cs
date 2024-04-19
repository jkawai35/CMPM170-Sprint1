using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Upgrade : MonoBehaviour
{
    public static Upgrade Instance;
    public GameOverScreen gameOverScreen;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI multText;
    public float money = 0.0f;
    public int moneyToInt = 0;
    public int price = 10;
    public int priceIncrease = 10;

    public float baseRate = 10.0f;
    public float multiplier = 1.0f;
    public float idleTime = 0.0f;
    private float lastTimeActivated;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject); // Ensures only one instance exists
    }

    private void Start()
    {
        lastTimeActivated = getCurrentTime();
    }
    void Update()
    {
        if (!gameOverScreen.stopGame)
        {
            float currentTime = getCurrentTime();
            float elapsedTime = currentTime - lastTimeActivated;

            //Acculate idle time
            idleTime += elapsedTime;

            //Calculate currency earned during idle time
            float currencyEarned = idleTime * (baseRate * multiplier);
            money += currencyEarned;

            moneyToInt = (int)Mathf.Round(money);
            moneyText.text = "Money: " + moneyToInt;
            multText.text = "Multiplier: " + multiplier;

            //reset last time activated
            lastTimeActivated = currentTime;
            //reset idle time
            idleTime = 0.0f;
        }
    }

    public float getCurrentTime()
    {
        return Time.time;
    }
    public void upgrade()
    {
        if (money >= price)
        {
            multiplier += 0.1f;
            money -= price;
            price += priceIncrease;
        }
    }
    public void resetCurrency()
    {
       money = 0.0f;
        multiplier = 1.0f;
    }
}
