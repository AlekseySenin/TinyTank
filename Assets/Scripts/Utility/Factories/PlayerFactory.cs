using System;
using Zenject;
using UnityEngine;

public class PlayerFactory : IFactory<HealthComponent>
{
    private LevelConfig _levelConfig;
    private DiContainer _container;

    public PlayerFactory(LevelConfig levelConfig, DiContainer container)
    {
        _levelConfig = levelConfig;
        _container = container;
    }
    public Action<HealthComponent> ActionOnGenerated { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public HealthComponent Generate()
    {
        GameObject playerInstance = _container.InstantiatePrefab(_levelConfig.PlayerPrefab);
        HealthComponent health = playerInstance.GetComponent<HealthComponent>();
        playerInstance.gameObject.SetActive(false);
        return health;
    }
}
