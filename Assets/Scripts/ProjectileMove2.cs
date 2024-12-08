using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove2 : MonoBehaviour
{
    public float speed = 10f; // Speed of the projectile
    public float lifetime = 5f; // Lifetime of the projectile
    public int damage = 1; // Damage dealt by the projectile

    void Start()
    {
        // Destroy the projectile after its lifetime expires
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Move the projectile forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Handle collision with other objects
        EnemyDamage enemyDamage = collision.collider.GetComponent<EnemyDamage>();
        if (enemyDamage != null)
        {
            enemyDamage.TakeDamage(damage);
        }

        // Destroy the projectile upon collision
        Destroy(gameObject);
    }
}