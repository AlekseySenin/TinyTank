using Zenject;
using UnityEngine;
using System.Linq;

public class Spike : MonoBehaviour,IDamageDiller
{
    [Inject] EnemyConfig config;
    [SerializeField] private Vector3 _collisionBoxSize = new Vector3(5, 5, 0.5f);
    [SerializeField] private Vector3 _collisionBoxOffset = new Vector3(0, 0, 1);
    [SerializeField] public LayerMask detectionLayer;

    public void DealDamage(HealthComponent health)
    {
        health.TakeDamage(config.Damage);
    }

    private void FixedUpdate()
    {
        Vector3 position = _collisionBoxOffset + transform.position;
        Collider[] overlappingColliders = Physics.OverlapBox(position, _collisionBoxSize / 2, Quaternion.identity, detectionLayer);
        Collider[] filteredColliders = overlappingColliders.Where(collider => (collider != gameObject.GetComponent<Collider>()))
    .ToArray(); ;
        foreach (var item in filteredColliders)
        {
            if(item.gameObject.TryGetComponent<HealthComponent>(out HealthComponent health))
            {
                health.TakeDamage(config.Damage);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Vector3 position = _collisionBoxOffset + transform.position;

        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(position, _collisionBoxSize);
    }

}
