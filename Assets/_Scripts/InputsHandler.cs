using System;
using UnityEngine;

public class InputsHandler : MonoBehaviour
{
    public event Action OnInstantiateAnchor;

    private void Update()
    {       
        if (Input.GetMouseButtonDown(0))
        {
            OnInstantiateAnchor?.Invoke();
        }
    }
}
