using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    
    private int _health;
    private bool _isDead;
    public bool IsDead { get { return _isDead; } }
    [SerializeField] private int _healthOnStart = 1;
    [SerializeField]  private GameObject _object;
    public GameObject Object { get { return _object; } }
    public Action OnDeath;
    public Action OnRespawn;

    private void Awake()
    {
        _health = _healthOnStart;
        _isDead = true;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        Debug.Log($"Object {gameObject.name} took {damage} damage. Remaining health: {_health}");

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDeath?.Invoke();
        _isDead = true;
        _object.SetActive(false);

    }

    public void Respawn()
    {
        OnRespawn?.Invoke();
        _health = _healthOnStart;
        _isDead = false;
    }


}
