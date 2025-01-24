using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private List<RespawnPoint> _respawnPoints;
    [SerializeField] private LevelConfig _levelConfig;
    [SerializeField] private List<HealthComponent> _enemyHealthComponents;
    [SerializeField] private HealthComponent _playerHealthComponent;
    [SerializeField] private GameObject _rootObject;

    public override void InstallBindings()
    {

        Container.BindInstance(_rootObject).AsSingle();

        Container.BindInstance(_levelConfig).AsSingle();


         BindRespawnPoints();
         BindPlayer();
        Container.Bind<ScoreHolder>().AsSingle().NonLazy();
        BindEnemies();
         Container.Bind<Respawner>().AsSingle().NonLazy();
    }
    private void BindRespawnPoints()
    {

        SpawnPointFactory spawnPointFactory = new SpawnPointFactory(_rootObject);
        _respawnPoints = spawnPointFactory.Generate();
        Container.BindInstance(_respawnPoints).AsSingle().NonLazy();

    }
    private void BindPlayer()
    {
        PlayerFactory playerFactory = new PlayerFactory(_levelConfig, Container);
        _playerHealthComponent = playerFactory.Generate();
        Container.BindInstance(_playerHealthComponent).AsSingle().NonLazy();

    }
    private void BindEnemies()
    {
        EnemyFactory enemyFactory = new EnemyFactory(_levelConfig,Container);
        _enemyHealthComponents = enemyFactory.Generate();
        Container.BindInstance(_enemyHealthComponents).AsSingle().NonLazy();
    }


}
