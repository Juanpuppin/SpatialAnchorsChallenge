using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class SceneContext : MonoInstaller
{
    public GameObject FreeFlyCamera;
    public GameObject Room;

    public override void InstallBindings()
    {
        Container.Bind<InputsHandler>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<AnchorsHandler>().FromComponentInHierarchy().AsSingle().NonLazy();

        Container.Bind<FreeFlyCamera>().FromComponentOn(FreeFlyCamera).AsSingle().NonLazy();
        Container.Bind<Room>().FromComponentOn(Room).AsSingle().NonLazy();
    }
}
