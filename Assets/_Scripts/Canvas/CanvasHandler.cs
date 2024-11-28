using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CanvasHandler : MonoBehaviour
{
    //Inject
    [Inject] private InputsHandler inputHandler;
    [Inject] private FreeFlyCamera freeFlyCamera;

    //private
    private List<CanvasInstance> canvasInstances = new List<CanvasInstance>();


    private void Awake()
    {
        CreateCanvasInstancesList();
    }


    private void OnEnable()
    {
        inputHandler.OnRoomSizeOpen += ToggleCanvas;
    }

    private void OnDisable()
    {
        inputHandler.OnRoomSizeOpen -= ToggleCanvas;
    }


    private void CreateCanvasInstancesList()
    {
        foreach (Transform child in transform)
        {
            if (child.TryGetComponent(out CanvasInstance canvasInstance))
            {
                canvasInstances.Add(canvasInstance);
            }
            else
            {
                Debug.LogError($"ERROR: {child.name} is a child of {transform.name} but lacks a CanvasInstance component.");
                return;
            }
        }
    }

    // Public
    public void ToggleCanvas(string _name, bool _activate)
    {
        foreach (CanvasInstance _canvasIntance in canvasInstances)
        {
            if (_canvasIntance.CanvasName == _name)
            {
                _canvasIntance.gameObject.SetActive(true);
                LockCamera(_name);
            }
            else if (!_canvasIntance.neverDeativate)
            {
                _canvasIntance.gameObject.SetActive(false);
            }
        }
    }

    private void LockCamera(string _activeCanvas) 
    {
        freeFlyCamera.ActivateUI(_activeCanvas == "HUD");       
    }
}

