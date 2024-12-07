using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab to be spawned
    public Transform[] spawnPoints; // Array of spawn points

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            GameObject enemyInstance = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            NavMeshAgent agent = enemyInstance.GetComponent<NavMeshAgent>();

            if (agent != null)
            {
                agent.Warp(spawnPoint.position); // Ensure the agent is placed correctly on the NavMesh
            }
            else
            {
                Debug.LogError("Enemy prefab does not have a NavMeshAgent component.");
            }
        }
    }
}