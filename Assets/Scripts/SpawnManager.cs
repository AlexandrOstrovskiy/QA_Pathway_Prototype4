using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    [SerializeField]
    private float spawnRange = 10.0f;
    private Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {

        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        spawnPosition = new Vector3(spawnPosX, 0, spawnPosZ);

        Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);
    }
}
