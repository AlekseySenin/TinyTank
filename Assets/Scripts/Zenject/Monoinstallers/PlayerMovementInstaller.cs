using UnityEngine;
using Zenject;

public class PlayerMovementInstaller : MonoInstaller
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

    void BindTankMover()
    {

        TankMover tankMover = new TankMover(_rigidbody);
        Container.Bind<TankMover>().FromInstance(tankMover).AsSingle().NonLazy();
    }
    void BindTankConfig()
    {
        Container.Bind<TankConfig>().FromInstance(_tankConfig).AsSingle().NonLazy();
    }
}