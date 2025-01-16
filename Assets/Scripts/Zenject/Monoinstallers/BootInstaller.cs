using UnityEngine;
using Zenject;

public class BootInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindScenLoader();
    }

    private void BindScenLoader()
    {
        SceneLoader sceneLoader = new SceneLoader();
        Container.Bind<SceneLoader>().FromInstance(sceneLoader).AsSingle().NonLazy();
    }
}