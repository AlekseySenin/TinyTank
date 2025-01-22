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

        
        Container.Bind<TankMover>().AsSingle().NonLazy();
    }
    void BindTankConfig()
    {
        Container.Bind<TankConfig>().FromInstance(_tankConfig).AsSingle().NonLazy();
    }
}