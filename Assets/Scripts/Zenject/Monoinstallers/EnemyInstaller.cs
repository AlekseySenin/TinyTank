using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
    [SerializeField] private EnemyConfig _enemyConfig;
    [SerializeField] private HealthComponent _healthComponent;
    public override void InstallBindings()
    {
        Container.Bind<EnemyConfig>().FromInstance(_enemyConfig).NonLazy();
        Container.Bind<HealthComponent>().FromInstance(_healthComponent).NonLazy();
    }
}