using System;
using Zenject;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointFactory : IFactory<List<RespawnPoint>>
{
    [Inject] private GameObject _rootObject;

    public SpawnPointFactory(GameObject rootObject)
    {
        _rootObject = rootObject;
    }
    public Action<List<RespawnPoint>> ActionOnGenerated { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public List<RespawnPoint> Generate()
    {
        if (_rootObject != null)
        {
            List<RespawnPoint> respawnPoints = new List<RespawnPoint>();
            RespawnPoint[] pointsInChildren = _rootObject.GetComponentsInChildren<RespawnPoint>();
            respawnPoints.AddRange(pointsInChildren);
            return respawnPoints;
        }
        else Debug.LogError("SpawnPointFactory can not Generate. _rootObject == null");
        return null;
    }
}
