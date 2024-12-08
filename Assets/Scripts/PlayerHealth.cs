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
        if (HUDManager != null && IsDead == false)
        {
            HUDManager.DecreaseHealth();
        }
        if (currentHealth <= 0)
        {
            IsDead = true;
            Die();
            Invoke ("DeathMenuON", 5f);
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
    
    void DeathMenuON()
    {
        DeathMenu deathMenu = FindObjectOfType<DeathMenu>();
        if (deathMenu != null)
        {
            deathMenu.ShowDeathMenu();
        }
        else
        {
            Debug.LogError("DeathMenu not found in the scene.");
        }
    }
    
}