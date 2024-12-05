using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class SpitAttack : MonoBehaviour
{
    public GameObject spitPrefab; // Assign the spit prefab
    public Transform spitOrigin; // Where the spit comes from (e.g., enemy's mouth)
    public float spitSpeed = 10f;

    public void Spit(Vector3 targetPosition)
    {
        // Instantiate the spit effect
        GameObject spit = Instantiate(spitPrefab, spitOrigin.position, Quaternion.identity);

        // Calculate direction
        Vector3 direction = (targetPosition - spitOrigin.position).normalized;

        // Add velocity to the spit
        Rigidbody rb = spit.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction * spitSpeed;
        }

        // Optionally, destroy the spit after a certain time
        Destroy(spit, 2f);
    }
}

