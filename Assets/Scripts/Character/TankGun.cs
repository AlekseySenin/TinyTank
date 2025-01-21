using UnityEngine;
using System.Collections;

public class TankGun : MonoBehaviour
{
    [SerializeField]
    private GunConfig gunConfig;

    [SerializeField]
    private ParticleSystem gunParticleSystem;

    private bool isOnCooldown = false;

    public void Shoot()
    {
        if (isOnCooldown)
        {
            Debug.Log("On cooldown!");
            return;
        }

        if (gunConfig.projectilePrefab != null)
        {
            Instantiate(gunConfig.projectilePrefab, transform.position, transform.rotation);
            Debug.Log("Projectile spawned!");
        }
        else
        {
            Debug.LogWarning("Projectile Prefab is not assigned in the configuration!");
        }

        if (gunParticleSystem != null)
        {
            gunParticleSystem.Play();
            Debug.Log("Shooting particle effect activated!");
        }
        else
        {
            Debug.LogWarning("GunParticleSystem is not assigned!");
        }

        StartCoroutine(CooldownCoroutine());
    }

    private IEnumerator CooldownCoroutine()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(gunConfig.cooldownTime);
        isOnCooldown = false;
        Debug.Log("Cooldown finished!");
    }
}