using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack Instance;
    private GameObject attackArea = default;

    public bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;

    public GameOverScreen gameOverScreen;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject); // Ensures only one instance exists
    }
    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        //calls attack function when key pressed down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack();
        }
        if (attacking)
        {
            timer += Time.deltaTime;

            //reset attack timer
            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }

    private void attack()
    {
        Upgrade.Instance.money -= 50;
        if (Upgrade.Instance.money <= 0)
        {
            gameOverScreen.GameOver();
        }
        attacking = true;
        attackArea.SetActive(attacking);
    }
}
