using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject door;

    public int price;
    public int minPrice = 100;
    public int maxPrice = 500;

    private void Start()
    {
        price = Random.Range(minPrice, maxPrice);
    }

    public void buyDoor()
    {
        if (Upgrade.Instance.money >= price)
        {
            door.SetActive(false);
            Upgrade.Instance.money -= price;
            Debug.Log("Bought door");
        }
        else
        {
            Debug.Log("Can't afford");
        }
    }
}
