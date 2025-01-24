using UnityEngine;
using Zenject;

public class TankMovementInstaller : MonoInstaller
{
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] TankConfig _tankConfig;

    public override void InstallBindings()
    {
        BindRigidBody();
        BindTankMover();
        BindTankConfig();
    }

    void BindRigidBody()
    {
        Container.Bind<Rigidbody>().FromInstance(_rigidbody).AsSingle().NonLazy();
    }

    void BindTankConfig()
    {
        Container.Bind<TankConfig>().FromInstance(_tankConfig).AsSingle().NonLazy();
    }

    void BindTankMover()
    {
        TankMover tankMover = new TankMover(_rigidbody,_tankConfig) ;
        Container.Bind<ITankMover>().FromInstance(tankMover).AsSingle().NonLazy();
        //Container.Bind<TankMover>().AsSingle().NonLazy();
    }
}