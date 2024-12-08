using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this script to the player
public class PlayerTarget : MonoBehaviour
{
    public GameObject targetPrefab; // Assign the target prefab

    void Start()
    {
        // Instantiate the target object as a child of the player
        GameObject target = Instantiate(targetPrefab, transform);
        target.transform.localPosition = new Vector3(0, 1, 0); // Adjust the position as needed
    }
}