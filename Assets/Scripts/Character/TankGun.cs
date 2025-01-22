using System;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class TankGun
{
    private readonly GunConfig _gunConfig;
    private readonly Transform _gunTransform;
    private readonly Projectile.Factory _projectileFactory;
    private ParticleSystem _gunParticleSystem;
    private bool isOnCooldown;


    [Inject]
    public TankGun(
        GunConfig gunConfig, 
        Transform gunTransform,
        Projectile.Factory projectileFactory, 
        ParticleSystem gunParticleSystem
        )
    {
        _gunConfig = gunConfig;
        _gunTransform = gunTransform;
        _projectileFactory = projectileFactory;
        _gunParticleSystem = gunParticleSystem;
    }

    public async Task Shoot()
    {
        if (isOnCooldown)
        {
            return;
        }

        if (_gunConfig.ProjectilePrefab != null)
        {
            Projectile projectile = _projectileFactory.Create();
            projectile.Initialize(_gunTransform.position, _gunTransform.rotation);

        }
        if(_gunParticleSystem != null)
        {
            _gunParticleSystem.Play();
        }
        else
        {
        }

        isOnCooldown = true;
        await Cooldown();
    }

    private async Task Cooldown()
    {
        await Task.Delay(TimeSpan.FromSeconds(_gunConfig.CooldownTime));
        isOnCooldown = false;
    }
}
