using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public static event Action DepletedHealth;
    [SerializeField] private int _maxHealth = 100;

    private int _currentHealth;

    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;
        if (_currentHealth > 0) return;

        _currentHealth = 0;
        DepletedHealth?.Invoke();

        // Died
        Debug.Log($"Entity {gameObject.name} died", this);
        Destroy(gameObject);
    }
}