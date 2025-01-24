using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/LevelConfig", order = 1)]
public class LevelConfig : ScriptableObject
{
    public float PlayerRespawnDelay;
    public float PlayerRespawnTime;
    public float EnemyRespawnDelay;
    public float EnemyRespawnTime;
    [Header("Player Settings")]
    public HealthComponent PlayerPrefab;

    [Header("Enemy Settings")]
    public List<HealthComponent> EnemyPrefabs;
}
