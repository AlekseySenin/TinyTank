using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    
    private int _health;
    private bool _isDead = true;
    public bool IsDead { get { return _isDead; } }
    [SerializeField] private int _healthOnStart = 1;
    [SerializeField]  private GameObject _object;
    public GameObject Object { get { return _object; } }
    public Action OnDeath;
    public Action OnRespawn;

    private void Awake()
    {
        _health = _healthOnStart;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _isDead = true;
        _object.SetActive(false);
        OnDeath?.Invoke();
    }

    public void Respawn()
    {
        _health = _healthOnStart;
        _isDead = false;
        OnRespawn?.Invoke();    
    }


}
