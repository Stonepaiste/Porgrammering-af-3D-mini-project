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
        rb.AddForce(spitSpawnPoint.forward * spitForce, ForceMode.Impulse);
    }
}
