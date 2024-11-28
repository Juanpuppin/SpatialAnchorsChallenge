using System;
using UnityEngine;

public class InputsHandler : MonoBehaviour
{
    public event Action OnInstantiateAnchor;

    private void Update()
    {    
        // Instantiate Anchors
        if (Input.GetKeyDown(KeyCode.F))
        {
            OnInstantiateAnchor?.Invoke();
        }
    }
}
