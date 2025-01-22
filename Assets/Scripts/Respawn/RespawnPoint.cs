using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    private List<Collider> collidersInTrigger = new List<Collider>();
    [SerializeField] private float detectionRadius = 5f;
    [SerializeField] private LayerMask detectionLayer;

    public bool IsVacant()
    {
        Collider[] overlappingColliders = Physics.OverlapSphere(transform.position, detectionRadius, detectionLayer);

        List<Collider> overlappingHealthObjects = overlappingColliders.ToList().FindAll(a => a.GetComponent<HealthComponent>());
        if (overlappingHealthObjects.Count == 0)
        {
            Debug.Log(gameObject.name+ "IsVacant");
            return true;
        }
        else
        {
            Debug.Log(gameObject.name + "IsNOTVacant");

            return false;
        }
    }
   
}
