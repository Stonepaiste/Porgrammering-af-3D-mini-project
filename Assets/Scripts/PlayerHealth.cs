// Purpose: Handle player health and death
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HUDManager HUDManager;
    public bool IsDead = false;
    void Start()
    {
        currentHealth = maxHealth;
    }
    

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        // Decrease health
        if (HUDManager != null && IsDead==false)
        {
            HUDManager.DecreaseHealth();
        }
        if (currentHealth <= 0)
        {
            IsDead = true;
            Die();
        }
    }

    void Die()
    {
        // Trigger death animation
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetTrigger("Death");
        }

        // Handle additional death logic
        Debug.Log("Player died!");
    }
}