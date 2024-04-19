using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameOverScreen gameOverScreen;

    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;
    //public CoinManager cm;
    int orbCount = 0;

    bool isMoving;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isMoving)
        {
            if (!gameOverScreen.stopGame)
            {
                moveInput.x = Input.GetAxisRaw("Horizontal");
                moveInput.y = Input.GetAxisRaw("Vertical");

                moveInput.Normalize();

                rb2d.velocity = moveInput * moveSpeed;
            }


            if (moveInput != Vector2.zero)
            {
                animator.SetFloat("moveX", moveInput.x);
                animator.SetFloat("moveY", moveInput.y);
                isMoving = true;
            }

            animator.SetBool("isMoving", isMoving);
        }

        isMoving = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!gameOverScreen.stopGame)
        {
            if (other.gameObject.CompareTag("Orb"))
            {
                Destroy(other.gameObject);

                //adjust multiplier and money values
                //money value can be changed
                Upgrade.Instance.multiplier += (float)0.5;
                Upgrade.Instance.money += 100;
                orbCount += 1;
                if (orbCount == 4)
                {
                    //game win UI here
                    gameOverScreen.Win();
                }
            }
            else if (other.gameObject.CompareTag("Enemy"))
            {
                if (!PlayerAttack.Instance.attacking)
                {
                    Destroy(other.gameObject);
                    //adjust multiplier and money values
                    Upgrade.Instance.multiplier -= (float)0.5;
                    Upgrade.Instance.money -= 200;
                    if (Upgrade.Instance.money <= 0 || Upgrade.Instance.multiplier <= 0)
                    {
                        //game over UI here
                        isMoving = false;
                        gameOverScreen.GameOver();
                    }
                }
            }
        }
        
    }
}
