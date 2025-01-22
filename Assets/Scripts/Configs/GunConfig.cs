using UnityEngine;

[CreateAssetMenu(menuName = "Configs/GunConfig")]
public class GunConfig : ScriptableObject
{
    public float CooldownTime;
    public GameObject ProjectilePrefab;
}