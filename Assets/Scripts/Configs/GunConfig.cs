using UnityEngine;

[CreateAssetMenu(menuName = "Configs/GunConfig")]
public class GunConfig : ScriptableObject
{
    public float cooldownTime;
    public GameObject projectilePrefab;
}