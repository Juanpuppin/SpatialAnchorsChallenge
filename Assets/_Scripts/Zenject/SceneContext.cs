using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class SceneContext : MonoInstaller
{
    public GameObject FreeFlyCamera;
    public GameObject Room;
    public GameObject Label;

    public override void InstallBindings()
    {
        Container.Bind<InputsHandler>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<AnchorsHandler>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<CanvasHandler>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<AnchorReachCanvas>().FromComponentInHierarchy().AsSingle().NonLazy();

        Container.Bind<FreeFlyCamera>().FromComponentOn(FreeFlyCamera).AsSingle().NonLazy();
        Container.Bind<Room>().FromComponentOn(Room).AsSingle().NonLazy();
        Container.Bind<Label>().FromComponentOn(Label).AsSingle().NonLazy();
    }
}
