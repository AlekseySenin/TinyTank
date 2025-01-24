using System;
using Zenject;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : IFactory<List<HealthComponent>>
{
    private LevelConfig _levelConfig;
    private DiContainer _container;

    [Inject]
    public EnemyFactory(LevelConfig levelConfig, DiContainer container)
    {

        _levelConfig = levelConfig;
        _container = container;
    }
    public Action<List<HealthComponent>> ActionOnGenerated { get; set; }

    public List<HealthComponent> Generate()
    {
        List<HealthComponent> componentsCreated = new List<HealthComponent>();
        foreach (var prefab in _levelConfig.EnemyPrefabs)
        {
            GameObject enemyInstance = _container.InstantiatePrefab(prefab);
            HealthComponent health = enemyInstance.GetComponent<HealthComponent>();
            enemyInstance.gameObject.SetActive(false);
            componentsCreated.Add(health);
        }
        return componentsCreated;
    }
}
