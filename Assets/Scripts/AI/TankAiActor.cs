using System.Collections;
using System.Collections.Generic;
using Zenject;
using UnityEngine;
using System.Linq;

public class TankAiActor : MonoBehaviour
{
    [SerializeField] private Vector3 _collisionBoxSize = new Vector3(5, 5, 0.5f);
    [SerializeField] private Vector3 _collisionBoxOffset = new Vector3(0, 0, 1);
    [SerializeField] public LayerMask detectionLayer;
    [Inject] protected ITankMover _tankMover;
    [Inject] protected TankConfig _tankConfig;
    public ITankMover TankMover { get { return _tankMover; } }

    public bool IsColliding()
    {
        Vector3 position = _collisionBoxOffset + transform.position;
        Collider[] overlappingColliders = Physics.OverlapBox(position, _collisionBoxSize / 2, Quaternion.identity, detectionLayer);
        Collider[] filteredColliders = overlappingColliders.Where(collider => collider != gameObject.GetComponent<Collider>())
    .ToArray();;
        return !(filteredColliders.Length == 0);
    }

    private void OnDrawGizmos()
    {
        Vector3 position = _collisionBoxOffset + transform.position;

        Gizmos.color = Color.blue;

        Gizmos.DrawWireCube(position, _collisionBoxSize);
    }
}
