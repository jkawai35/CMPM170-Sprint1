using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Namespace required for TextMeshPro elements

public class Door : MonoBehaviour
{
    public GameObject door; // The door GameObject that should be disabled when bought
    public int price; // The price to buy the door
    public int minPrice = 100; // Minimum price range for the door
    public int maxPrice = 500; // Maximum price range for the door
    public TextMeshProUGUI messageText; // UI Text element to display messages

    void Start()
    {
        price = Random.Range(minPrice, maxPrice); // Set a random price within the range at start
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // Check if the colliding object is the player
        {
            TryToBuyDoor();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // Check if it is the player exiting the trigger
        {
            messageText.text = ""; // Clear the message text
        }
    }

    public void TryToBuyDoor()
    {
        if (Upgrade.Instance.money >= price) // Check if the player has enough money
        {
            Upgrade.Instance.money -= price; // Deduct the price from the player's money
            //messageText.text = "Door bought successfully!"; // Show success message 
            //The text kept staying on screen. I think its because once it's setActive is off, there
            //is no way of the door knowing if the player walked away. I decided to comment it out.
            Debug.Log("Bought door");
            door.SetActive(false); // Disable the door GameObject
        }
        else
        {
            messageText.text = "You don't have enough money lol"; // Show failure message
            Debug.Log("Can't afford");
        }
    }
}
