using System;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int currentHealth = 3;
    public int scoreValue = 500;
    [SerializeField] private GameObject _replacement;
    private HUDManager _hudManager;

    private void Start()
    {
        _hudManager = FindObjectOfType<HUDManager>();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            if (_hudManager != null)
            {
                _hudManager.AddScore(scoreValue);
            }
            Instantiate(_replacement, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}