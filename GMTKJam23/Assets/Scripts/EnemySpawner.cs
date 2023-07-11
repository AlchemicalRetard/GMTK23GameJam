using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemyPrefabs;
    public SpawnPointManager spawnPointManager;
    public int numberOfWaves = 5;
    private float spawnInterval = 2f;
    private int currentWave = 1;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            foreach (var spawnPoint in spawnPointManager.spawnPoints)
            {
                // choose a random enemy type to spawn
                GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

                var enemy =  Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation).GetComponent<AIDestinationSetter>();
                enemy.target = FindObjectOfType<PlayerMovement>().transform;
                yield return new WaitForSeconds(spawnInterval);
            }
            spawnInterval *= 0.9f; // decrease the spawn interval by 10% with each wave
        }
    }
}