using UnityEngine;
using Zenject;

public class Projectile : MonoBehaviour, IDamageDiller
{
    [SerializeField]
    private ProjectileConfig projectileConfig;

    private void Start()
    {
        Destroy(gameObject, projectileConfig.Lifetime);
    }

    private void FixedUpdate()
    {
        transform.Translate(transform.forward * projectileConfig.Speed * Time.fixedDeltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        HealthComponent healthComponent = collision.gameObject.GetComponent<HealthComponent>();

        if (healthComponent != null)
        {
            DealDamage(healthComponent);
        }

        if (projectileConfig.ExplosionParticles != null)
        {
            Instantiate(projectileConfig.ExplosionParticles, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    
    public void Initialize(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
        transform.SetParent(null);
    }

    public void DealDamage(HealthComponent health)
    {
        health.TakeDamage(projectileConfig.Damage);
    }

    public class Factory : PlaceholderFactory<Projectile> { }
}