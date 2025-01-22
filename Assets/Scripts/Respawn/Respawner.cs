using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Respawner 
{
     private List<RespawnPoint> _respawnPoints;
     private RespawnConfig _respawnConfig;
     private List<HealthComponent> _enemyHealthComponents;
     private HealthComponent _playerHealthComponent;

    [Inject] public Respawner
        (
        List<RespawnPoint> respawnPoints,
        RespawnConfig respawnConfig,
        List<HealthComponent> enemyHealthComponents,
        HealthComponent playerHealthComponent
        )
    {
        _respawnPoints = respawnPoints;
        _respawnConfig = respawnConfig;
        _enemyHealthComponents = enemyHealthComponents;
        _playerHealthComponent = playerHealthComponent;
        Start();
    }

    private async void Start()
    {
        await TrySpawnPlayer(1.0f);
        await TrySpawnEnemies(1.0f);
    }
    private void SpawnObject(HealthComponent healthComponent, RespawnPoint respawnPoint)
    {

        Debug.Log(healthComponent.Object.transform.position);
        Debug.Log(respawnPoint.transform.position);
        healthComponent.Object.transform.position = respawnPoint.transform.position;
        healthComponent.Object.SetActive(true);
        healthComponent.Respawn();
    }

    public async Task TrySpawnPlayer(float delay)
    {
        await Task.Delay((int)(delay * 1000));

        if (AreFreeSpawnPoints())
        {
            SpawnObject(_playerHealthComponent, GetRandomFreeRespawnPoint());
        }
        else
        {
            await TrySpawnPlayer(_respawnConfig.PlayerRespawnTime);
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
            foreach (var item in GetAllFreePoints())
            {
                if (AreAllEnemiesAlive())
                {
                    return;
                }
                SpawnObject(GetRandomDeadEnemy(), GetRandomFreeRespawnPoint());
            }
        }

        if (!AreAllEnemiesAlive())
        {
            await TrySpawnEnemies(_respawnConfig.PlayerRespawnTime);
        }
    }
  
   private RespawnPoint GetRandomFreeRespawnPoint()
    {
        List<RespawnPoint> freeRespawnPoints = GetAllFreePoints();

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
    
    private bool AreFreeSpawnPoints()
    {
        return GetAllFreePoints().Count > 0;
    }
   
    private List<RespawnPoint> GetAllFreePoints()
    {
        return _respawnPoints.FindAll(a => a.IsFree);
    }
    
    private List<HealthComponent> GetAllDeadEnemies()
    {
        return _enemyHealthComponents.FindAll(a => a.IsDead);
    }
}
