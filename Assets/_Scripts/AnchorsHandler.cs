using System;
using UnityEngine;
using Zenject;

public class AnchorsHandler : MonoBehaviour
{
    //Inject
    [Inject] private AnchorsFactory anchorsFactory;
    [Inject] private readonly InputsHandler inputsHandler;
    [Inject] private readonly FreeFlyCamera freeFlyCamera;

    //Visible in the Inspector
    [SerializeField] private Transform anchorsParent;
    [SerializeField] private float distancesVerificationInterval = 0.5f;

    //Private
    private float checkInterval;

    //Public
    public event Action OnCheckDistances;

    private void OnEnable()
    {
        inputsHandler.OnInstantiateAnchor += InstantiateAnchor;
        freeFlyCamera.OnCameraMove += OnCameraMove;
    }
    private void OnDisable()
    {
        inputsHandler.OnInstantiateAnchor -= InstantiateAnchor;
        freeFlyCamera.OnCameraMove -= OnCameraMove;
    }
   
    [Inject] public void Construct(AnchorsFactory _anchorsFactory)
    {
        anchorsFactory = _anchorsFactory;
    }

    private void InstantiateAnchor()
    {
        if (freeFlyCamera.CameraRef == null) return;

        Ray _ray = freeFlyCamera.CameraRef.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out RaycastHit hitInfo))
        {
            var _anchor = anchorsFactory.Create();
            _anchor.transform.position = hitInfo.point;
            _anchor.transform.parent = anchorsParent;
            _anchor.StoreLocalPosition();

            OnCheckDistances?.Invoke();
        }
    }


    private void OnCameraMove()
    {
        checkInterval -= Time.deltaTime;
        if (checkInterval <= 0f)
        {
            checkInterval = distancesVerificationInterval;
            OnCheckDistances?.Invoke();
        }
    }
}
