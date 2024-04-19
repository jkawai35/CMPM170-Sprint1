using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameOverScreen gameOverScreen;

    [SerializeField]
    private GameObject[] enemyPrefab;

    [SerializeField]
    private float minimumSpawnTime;

    [SerializeField]
    private float maximumSpawnTime;

    private float timeUntilSpawn;
    private float spawnCounter;


    // Start is called before the first frame update
    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOverScreen.stopGame)
        {
            timeUntilSpawn -= Time.deltaTime;

            if (timeUntilSpawn <= 0)
            {
                int rand = Random.Range(0, enemyPrefab.Length);
                GameObject enemyToSpawn = enemyPrefab[rand]; //Spawn either bunny or crow
                Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
                spawnCounter += 1;
                if (spawnCounter >= 10)
                {
                    if (maximumSpawnTime > minimumSpawnTime)
                    {
                        maximumSpawnTime -= 0.5f;
                        spawnCounter = 0;
                    }
                }
                SetTimeUntilSpawn();
            }
        }
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }
}
