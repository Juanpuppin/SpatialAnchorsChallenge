using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class SceneInstaller : MonoInstaller
{   
    public override void InstallBindings()
    {
        Container.Bind<InputsHandler>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<AnchorsHandler>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<CanvasHandler>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<AnchorReachCanvas>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<FreeFlyCamera>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<Room>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<Label>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}
