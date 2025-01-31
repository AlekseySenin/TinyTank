using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class Respawner 
{
     private List<RespawnPoint> _respawnPoints;
     private LevelConfig _LevelConfig;
     private List<HealthComponent> _enemyHealthComponents;
     private HealthComponent _playerHealthComponent;

    [Inject] public Respawner(List<RespawnPoint> respawnPoints,
                                LevelConfig config,
                                    List<HealthComponent> enemyHealthComponents,
                                        HealthComponent playerHealthComponent)
    {
        _respawnPoints = respawnPoints;
        _LevelConfig = config;
        _enemyHealthComponents = enemyHealthComponents;
        _playerHealthComponent = playerHealthComponent;
        BindActions();
        
        Start();
    }
    ~Respawner()
    {
        UnbindEnemyActions();
    }
    private async void Start()
    {
        await TrySpawnPlayer(1.0f);
        await TrySpawnEnemies(1.0f);
    }
    public async Task TrySpawnPlayer(float spawnTime)
    {
        await Task.Delay((int)(spawnTime * 1000));

        if (AreFreeSpawnPoints())
        {
            SpawnObject(_playerHealthComponent, GetRandomFreeRespawnPoint());
            await Task.Delay((int)(_LevelConfig.PlayerRespawnDelay * 1000));
        }
        else
        {
            await TrySpawnPlayer(_LevelConfig.PlayerRespawnTime);
        }
    }
    public async Task TrySpawnEnemies(float delay)
    {
        await Task.Delay((int)(delay * 1000));
        if (AreAllEnemiesAlive())
        {

            return;
        }
        if (AreFreeSpawnPoints())
        {

            foreach (var item in GetAllVacantPoints())
            {
                if (AreAllEnemiesAlive())
                {
                    return;
                }
                SpawnObject(GetRandomDeadEnemy(), GetRandomFreeRespawnPoint());
                await Task.Delay((int)(_LevelConfig.EnemyRespawnDelay * 1000));
            }
        }

        if (!AreAllEnemiesAlive())
        {

            await TrySpawnEnemies(_LevelConfig.PlayerRespawnTime);
        }
    }
    private void SpawnObject(HealthComponent healthComponent, RespawnPoint respawnPoint)
    {
        healthComponent.Object.transform.position = respawnPoint.transform.position;
        healthComponent.Object.SetActive(true);
        healthComponent.Respawn();
    }
    private RespawnPoint GetRandomFreeRespawnPoint()
    {
        List<RespawnPoint> freeRespawnPoints = GetAllVacantPoints();

            int randomPoint = Random.Range(0, freeRespawnPoints.Count);
            return freeRespawnPoints[randomPoint];

    }  
    private HealthComponent GetRandomDeadEnemy()
    {
        List<HealthComponent> deadEnemies = GetAllDeadEnemies();
        if (deadEnemies.Count > 0)
        {
            int randomEnemy = Random.Range(0, deadEnemies.Count);
            return deadEnemies[randomEnemy];
        }

        return null;
    } 
    private bool AreAllEnemiesAlive()
    {
        return GetAllDeadEnemies().Count == 0;
    }
    private bool AreAllEnemiesDead()
    {
       return GetAllDeadEnemies().Count == _enemyHealthComponents.Count;
    }
    private bool AreFreeSpawnPoints()
    {
        return GetAllVacantPoints().Count > 0;
    }  
    private List<RespawnPoint> GetAllVacantPoints()
    {
        return _respawnPoints.FindAll(a => a.IsVacant());
    }  
    private List<HealthComponent> GetAllDeadEnemies()
    {
        return _enemyHealthComponents.FindAll(a => a.IsDead);
    }
    private async void ProcessEnemyDeath()
    {
        if (AreAllEnemiesDead())
        {
        await TrySpawnEnemies(_LevelConfig.EnemyRespawnTime);
        }
    }
    private async void ProcessPlayerDeath()
    {
        await TrySpawnPlayer(_LevelConfig.PlayerRespawnTime);
    }

    private void BindActions()
    {
        _playerHealthComponent.OnDeath += ProcessPlayerDeath;

        foreach (var item in _enemyHealthComponents)
        {
            item.OnDeath += ProcessEnemyDeath;
        }
    }
    private void UnbindEnemyActions()
    {
        _playerHealthComponent.OnDeath -= ProcessPlayerDeath;

        foreach (var item in _enemyHealthComponents)
        {
            item.OnDeath += ProcessEnemyDeath;
        }
    }

}
