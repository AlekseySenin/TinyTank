using Zenject;
using UnityEngine;

public class ScorableObject : MonoBehaviour
{
    [Inject] private EnemyConfig _enemyConfig;
    [Inject] private ScoreHolder _scoreHolder;
    [Inject] private HealthComponent _healthComponent;

    private void Start()
    {
        _healthComponent.OnDeath += SendScore;
    }

    private void OnDestroy()
    {
        _healthComponent.OnDeath -= SendScore;
    }

    void SendScore()
    {
        _scoreHolder.AddScore(_enemyConfig.ScorePrice);
    }
}
