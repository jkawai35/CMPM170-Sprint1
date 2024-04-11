using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrade : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public int money = 0;
    public int moneyRate = 0;
    public int price = 100;
    public int priceIncrease = 100;
    public void openUpgrade()
    {
        Debug.Log("Attempt to upgrade");
        if (money >= price)
        {
            moneyRate += 10;
            price = price + priceIncrease;
            Debug.Log("Purchase upgrade");
        }
        else
        {
            Debug.Log("Insufficient funds");
        }
    }

    private void Update()
    {
        money += 1;
        moneyText.text = "Money: " + money;
    }
}
