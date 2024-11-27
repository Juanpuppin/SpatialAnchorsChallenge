using UnityEngine;
using Zenject;

public class AnchorsHandler : MonoBehaviour
{
    //Show in Inspector
    [SerializeField] private GameObject AnchorPrefab;

    //Private Fields
    [Inject] private readonly InputsHandler inputsHandler;
    [Inject] private readonly FreeFlyCamera freeFlyCamera;

    private void OnEnable()
    {
        inputsHandler.OnInstantiateAnchor += InstantiateAnchor;
    }
    private void OnDisable()
    {
        inputsHandler.OnInstantiateAnchor -= InstantiateAnchor;
    }

    private void InstantiateAnchor()
    {
        if (freeFlyCamera.CameraRef == null) return;

        Ray _ray = freeFlyCamera.CameraRef.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out RaycastHit hitInfo))
        {
            Instantiate(AnchorPrefab, hitInfo.point, Quaternion.identity);
        }
    }
}
