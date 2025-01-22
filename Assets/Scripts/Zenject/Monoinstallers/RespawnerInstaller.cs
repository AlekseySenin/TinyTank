using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RespawnerInstaller : MonoInstaller
{
    [SerializeField] private List<RespawnPoint> _respawnPoints;
    [SerializeField] private RespawnConfig _respawnConfig;
    [SerializeField] private List<HealthComponent> _enemyHealthComponents;
    [SerializeField] private HealthComponent _playerHealthComponent;

    public override void InstallBindings()
    {
        Container.BindInstance(_respawnPoints).AsSingle();

        Container.BindInstance(_respawnConfig).AsSingle();

        Container.BindInstance(_enemyHealthComponents).AsSingle();

        Container.BindInstance(_playerHealthComponent).AsSingle();

        Container.Bind<Respawner>().AsSingle().NonLazy();
    }
}
