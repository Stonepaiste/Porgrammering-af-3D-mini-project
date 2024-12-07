using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitAttack : MonoBehaviour
{
    public GameObject spitPrefab; // Assign the spit prefab
    public Transform spitOrigin; // Where the spit comes from (e.g., enemy's mouth)
    public float spitSpeed = 10f;
    public Transform player; // Reference to the player

    public void Spit()
    {
        // Instantiate the spit effect
        GameObject spit = Instantiate(spitPrefab, spitOrigin.position, Quaternion.identity);

        // Calculate direction towards the player
        Vector3 direction = (player.position - spitOrigin.position).normalized;

        // Add an upward component to the direction
        Vector3 angledDirection = direction + Vector3.up * 45f; // Adjust the upward component as needed
        angledDirection.Normalize();

        // Add velocity to the spit
        Rigidbody rb = spit.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = angledDirection * spitSpeed;
        }

        // Configure the particle system's shape module
        ParticleSystem particleSystem = spit.GetComponent<ParticleSystem>();
        if (particleSystem != null)
        {
            var shape = particleSystem.shape;
            shape.angle = 45f; // Set the desired angle
            shape.rotation = new Vector3(0, 0, 0); // Adjust rotation if needed
        }

        // Optionally, destroy the spit after a certain time
        Destroy(spit, 2f);
    }
}
