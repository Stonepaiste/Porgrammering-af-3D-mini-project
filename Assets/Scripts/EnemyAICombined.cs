using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAICombined : MonoBehaviour
{
    public Transform[] waypoints;
    public GameObject player;
    public GameObject spitPrefab;
    public Transform spitSpawnPoint;
    public float spitForce = 10f;
    public float attackCooldown = 2f;
    public int range; // if player is within this range, enemy will follow
    public int tetherRange; // if player goes out of range, enemy will return to this range

    public NavMeshAgent agent;
    private int currentWaypointIndex = 0;
    private float attackTimer = 0f;
    //private Vector3 startPosition;
    private GameObject currentTarget;
    private PlayerDetection detection;
    private bool AttackNOW = false;
    PlayerHealth playerHealth;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        detection = GetComponent<PlayerDetection>();
        //startPosition = this.transform.transform.position;
        agent.updateRotation = false; // Disable automatic rotation
        agent.SetDestination(waypoints[currentWaypointIndex].transform.position);
        InvokeRepeating("DistanceCheck", 0, 0.5f);
        playerHealth = player.GetComponent<PlayerHealth>(); // Get the PlayerHealth component
    }

    void Update()
    {
        Patrol();
        FollowPlayer();
        AttackPlayer();
        
    }

    void Patrol()
    {
        if (currentTarget == null && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            agent.SetDestination(waypoints[currentWaypointIndex].transform.position);
        }

        // Manually rotate the worm to face the direction of movement
        if (agent.velocity.sqrMagnitude > Mathf.Epsilon)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.up, agent.velocity.normalized);
        }
    }

    void FollowPlayer()
    {
        if (currentTarget != null && playerHealth != null && playerHealth.IsDead==false)
        {
            agent.SetDestination(currentTarget.transform.position);
            AttackNOW = true;
        }
        else if (agent.destination != waypoints[currentWaypointIndex].transform.position)
        {
            agent.SetDestination(waypoints[currentWaypointIndex].transform.position);
            AttackNOW = false;
        }
      
    }

    void AttackPlayer()
    {
        if (AttackNOW==true)
        {
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
        GameObject spit = Instantiate(spitPrefab, spitSpawnPoint.transform.position, Quaternion.identity);
        Rigidbody rb = spit.GetComponent<Rigidbody>();

        // Calculate direction towards the player
        Vector3 direction = (player.transform.position - spitSpawnPoint.transform.position).normalized;

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

    void DistanceCheck()
    {
        float dist = Vector3.Distance(this.transform.position, player.transform.position);
        if (dist < range)
        {
            currentTarget = player;
        }
        else if (dist > tetherRange)
        {
            currentTarget = null;
        }
    }
}