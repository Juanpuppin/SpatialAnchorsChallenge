using UnityEngine;
using Zenject;

public class PrefabsInstaller : MonoInstaller
{
    [SerializeField] private GameObject anchorPrefab;

    public override void InstallBindings()
    {
        Container.BindFactory<Anchor, AnchorsFactory>().FromComponentInNewPrefab(anchorPrefab).AsTransient();
    }
}
