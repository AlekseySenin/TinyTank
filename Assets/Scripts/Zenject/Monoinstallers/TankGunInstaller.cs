using UnityEngine;
using Zenject;

public class TankGunInstaller : MonoInstaller
{
    [SerializeField] private GunConfig _gunConfig;
    [SerializeField] private Transform _gunTransform;
    [SerializeField] private ParticleSystem _gunParticleSystem;
    [SerializeField] private Projectile projectilePrefab;


    public override void InstallBindings()
    {
        BindGunConfig();
        BindParticleSystem();
        BindTransform();
        BindProjectileFactory();
        BindTankGun();
    }

    void BindGunConfig()
    {
        Container.Bind<GunConfig>().FromInstance(_gunConfig).AsSingle();
    }
    void BindParticleSystem()
    {
        Container.Bind<ParticleSystem>().FromInstance(_gunParticleSystem).AsSingle();
    }

    void BindTransform()
    {
        Container.Bind<Transform>().FromInstance(_gunTransform).AsSingle();
    }
    void BindProjectileFactory()
    {
        Container.BindFactory<Projectile, Projectile.Factory>()
           .FromComponentInNewPrefab(projectilePrefab);
    }

    void BindTankGun()
    {
        Container.Bind<TankGun>().AsSingle().NonLazy(); ;
    }

}