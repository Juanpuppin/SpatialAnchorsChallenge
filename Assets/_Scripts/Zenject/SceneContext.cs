using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class SceneContext : MonoInstaller
{
    public GameObject FreeFlyCamera;

    public override void InstallBindings()
    {
        Container.Bind<InputsHandler>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<FreeFlyCamera>().FromComponentOn(FreeFlyCamera).AsSingle().NonLazy();
    }
}
