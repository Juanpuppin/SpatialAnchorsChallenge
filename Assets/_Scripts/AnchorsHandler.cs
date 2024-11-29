using System;
using UnityEditor.PackageManager;
using UnityEngine;
using Zenject;

public class AnchorsHandler : MonoBehaviour
{
    //Inject
    [Inject] private AnchorsFactory anchorsFactory;
    [Inject] private readonly InputsHandler inputsHandler;
    [Inject] private readonly FreeFlyCamera freeFlyCamera;
    [Inject] private readonly Label label;
    [Inject] private AnchorReachCanvas anchorReach;
    [Inject] private CanvasHandler canvasHandler;

    //Visible in the Inspector
    [SerializeField] private Transform anchorsParent;
    [SerializeField] private float distancesVerificationInterval = 0.5f;

    //Private
    private float checkTime;

    //Public
    public event Action OnCheckDistances;

    private void OnEnable()
    {
        inputsHandler.OnInstantiateAnchor += InstantiateNewAnchor;
        freeFlyCamera.OnCameraMove += OnCameraMove;
    }
    private void OnDisable()
    {
        inputsHandler.OnInstantiateAnchor -= InstantiateNewAnchor;
        freeFlyCamera.OnCameraMove -= OnCameraMove;
    }

    [Inject]
    public void Construct(AnchorsFactory _anchorsFactory)
    {
        anchorsFactory = _anchorsFactory;
    }

    private void Update()
    {
        PlaceLabel();
    }

    private void InstantiateNewAnchor()
    {
        if (RaycastCheck(out RaycastHit _hitInfo) && _hitInfo.collider.CompareTag("surface"))
        {
            var anchor = anchorsFactory.Create();
            anchor.transform.position = _hitInfo.point;
            anchor.transform.parent = anchorsParent;
            anchor.StoreLocalPosition();

            canvasHandler.ToggleCanvas("AnchorReach", true);
            anchorReach.SetAnchorReach(anchor);
        }
    }

    private void PlaceLabel()
    {
        if (RaycastCheck(out RaycastHit _hitInfo))
        {
            if (_hitInfo.collider.CompareTag("anchor"))
            {
                label.UpdateLabelPosition(_hitInfo.collider.GetComponent<Anchor>());
            }
            else
            {
                label.DeactivateLabel();
            }
        }
    }

    private void OnCameraMove()
    {
        checkTime += Time.deltaTime;
        if (checkTime >= distancesVerificationInterval)
        {
            checkTime = 0f;
            OnCheckDistances?.Invoke();
        }
    }

    private bool RaycastCheck(out RaycastHit _hitInfo)
    {
        Ray ray = freeFlyCamera.CameraRef.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out _hitInfo);
    }
}
