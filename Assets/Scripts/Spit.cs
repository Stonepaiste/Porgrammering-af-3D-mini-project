using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit : MonoBehaviour
{
    public int damageAmount = 10; // Amount of damage to deal to the player

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Damage the player
          PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                
                Invoke("WaitToDestroy", 3f);
            }
            Debug.Log("Player hit!");
        }
       
    }
    void WaitToDestroy()
    {
        Destroy(gameObject);
    }
}