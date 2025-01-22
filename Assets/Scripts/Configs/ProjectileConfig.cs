using UnityEngine;

[CreateAssetMenu(menuName = "Configs/ProjectileConfig")]
public class ProjectileConfig : ScriptableObject
{
    public int Damage;
    public float Speed;
    public float Lifetime;
    public ParticleSystem ExplosionParticles;
}
