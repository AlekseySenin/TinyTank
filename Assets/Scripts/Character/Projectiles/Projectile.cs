using UnityEngine;
using Zenject;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private ProjectileConfig projectileConfig;

    private void Start()
    {
        Debug.Log(gameObject.name);
        Destroy(gameObject, projectileConfig.Lifetime);
    }

    private void FixedUpdate()
    {
        transform.Translate(transform.forward * projectileConfig.Speed * Time.fixedDeltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
        HealthComponent healthComponent = collision.gameObject.GetComponent<HealthComponent>();

        if (healthComponent != null)
        {
            healthComponent.TakeDamage(projectileConfig.Damage);
        }

        if (projectileConfig.ExplosionParticles != null)
        {
            Instantiate(projectileConfig.ExplosionParticles, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    
    public void Initialize(Vector3 position, Quaternion rotation)
    {
        Debug.Log("projectile Initialized   " + position);
        transform.position = position;
        transform.rotation = rotation;
    }

    public class Factory : PlaceholderFactory<Projectile> { }
}