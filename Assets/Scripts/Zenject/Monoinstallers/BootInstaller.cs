using UnityEngine;
using Zenject;

public class BootInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindScenLoader();
        BindPlayerInputActions();
    }

    private void BindScenLoader()
    {
        SceneLoader sceneLoader = new SceneLoader();
        Container.Bind<SceneLoader>().FromInstance(sceneLoader).AsSingle().NonLazy();
    }

    private void BindPlayerInputActions()
    {
        PlayerInputActions inputActions = new PlayerInputActions();
        Container.Bind<PlayerInputActions>().FromInstance(inputActions).AsSingle().NonLazy();
    }
}