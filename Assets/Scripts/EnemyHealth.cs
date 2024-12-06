
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth = 3;
    public List<GameObject> meshParts = new List<GameObject>(); // List of mesh parts to be destroyed
    public int minPartsToEnable = 1; // Minimum number of parts to enable on each hit
    public int maxPartsToEnable = 5; // Maximum number of parts to enable on each hit

    void Start()
    {
        // Find and add all child mesh parts to the list
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            if (child != transform && child.GetComponent<MeshRenderer>() != null)
            {
                meshParts.Add(child.gameObject);
                var rb = child.GetComponent<Rigidbody>(); // Get Rigidbody component
                var collider = child.GetComponent<MeshCollider>();
                if (rb != null) rb.isKinematic = true; // Disable Rigidbody
                if (collider != null) collider.enabled = false; // Disable MeshCollider
            }
        }
    }

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            EnableAllMeshParts();
            Destroy(gameObject);
        }
        else
        {
            EnableRandomMeshParts();
        }
    }

    private void EnableRandomMeshParts()
    {
        int partsToEnable = Random.Range(minPartsToEnable, maxPartsToEnable + 1);
        for (int i = 0; i < partsToEnable && meshParts.Count > 0; i++)
        {
            int randomIndex = Random.Range(0, meshParts.Count);
            GameObject partToEnable = meshParts[randomIndex];
            meshParts.RemoveAt(randomIndex);
            var rb = partToEnable.GetComponent<Rigidbody>();
            var collider = partToEnable.GetComponent<MeshCollider>();
            if (rb != null) rb.isKinematic = false; // Enable Rigidbody
            if (collider != null) collider.enabled = true; // Enable MeshCollider
        }
    }

    private void EnableAllMeshParts()
    {
        foreach (GameObject part in meshParts)
        {
            var rb = part.GetComponent<Rigidbody>();
            var collider = part.GetComponent<MeshCollider>();
            if (rb != null) rb.isKinematic = false; // Enable Rigidbody
            if (collider != null) collider.enabled = true; // Enable MeshCollider
        }
        meshParts.Clear();
    }
}