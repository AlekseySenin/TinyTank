using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    private List<Collider> collidersInTrigger = new List<Collider>();
    public bool IsFree { get { return collidersInTrigger.Count == 0; } }

    private void OnTriggerEnter(Collider other)
    {
        collidersInTrigger.Add(other);
    }
    private void OnTriggerExit(Collider other)
    {
        collidersInTrigger.Remove(other);
    }
}
