using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WormAttack : MonoBehaviour
{
    public Transform player;
    public GameObject spitPrefab;
    public Transform spitSpawnPoint;
    public float spitForce = 10f;
    public float attackCooldown = 2f;
    private float attackTimer = 0f;

    private NavMeshAgent agent;
    private PlayerDetection detection;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        detection = GetComponent<PlayerDetection>();
    }

    void Update()
    {
        if (detection.IsPlayerDetected())
        {
            agent.SetDestination(player.position);

            attackTimer += Time.deltaTime;
            if (attackTimer >= attackCooldown)
            {
                Attack();
                attackTimer = 0f;
            }
        }
    }

    void Attack()
    {
        GameObject spit = Instantiate(spitPrefab, spitSpawnPoint.position, Quaternion.identity);
        Rigidbody rb = spit.GetComponent<Rigidbody>();

        // Calculate direction towards the player
        Vector3 direction = (player.position - spitSpawnPoint.position).normalized;

        // Add an upward component to the direction
        Vector3 angledDirection = direction + Vector3.up * 0.2f; // Adjust the upward component as needed
        angledDirection.Normalize();

        // Add velocity to the spit
        if (rb != null)
        {
            rb.velocity = angledDirection * spitForce;
        }

        // Apply additional force to simulate gravity
        rb.AddForce(Vector3.down * 9.81f, ForceMode.Acceleration);

        // Optionally, destroy the spit after a certain time
        Destroy(spit, 2f);
    }
}