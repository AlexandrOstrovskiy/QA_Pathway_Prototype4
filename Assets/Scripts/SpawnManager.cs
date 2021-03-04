using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    public GameObject player;

    private int enemyCount;
    //private int powerUpCount;
    private int enemyWaveCount = 1;

    [SerializeField]
    private float spawnRange = 10.0f;

    private Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        //InvokeRepeating("SpawnEnemy", 2.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (player.transform.position.y < -5)
            RessurectPlayer();
        if (enemyCount == 0)
        {
            SpawnEnemyWave(enemyWaveCount++);
            SpawnPowerUp();
        }
    }

    void RessurectPlayer()
    {
        //new WaitForSeconds(8);
        player.transform.position = Vector3.zero;
        //enemyWaveCount = 1;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int q = 0; q < enemiesToSpawn; q++)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {

        spawnPosition = SpawnSpotRandom();

        Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);
    }

    void SpawnPowerUp()
    {
        Instantiate(powerUpPrefab, SpawnSpotRandom(), powerUpPrefab.transform.rotation);
    }

    Vector3 SpawnSpotRandom()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        spawnPosition = new Vector3(spawnPosX, 0, spawnPosZ);
        return (spawnPosition);
    }
}
