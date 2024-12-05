using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 10f;
    public bool playerDetected = false;

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < detectionRange)
        {
            playerDetected = true;
        }
        else
        {
            playerDetected = false;
        }
    }

    public bool IsPlayerDetected()
    {
        return playerDetected;
    }
}

