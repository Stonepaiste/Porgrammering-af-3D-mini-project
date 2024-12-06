using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int currentHealth = 3;
    [SerializeField] private GameObject _replacement;

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Instantiate(_replacement, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}