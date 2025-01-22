using UnityEngine;
[CreateAssetMenu(menuName = "Configs/RespawnConfig")]

public class RespawnConfig : ScriptableObject
{
    public float PlayerRespawnTime;
    public float PlayerRespawnDelay;
    public float EnemyRespawnTime;
    public float EnemyRespawnDelay;
}
