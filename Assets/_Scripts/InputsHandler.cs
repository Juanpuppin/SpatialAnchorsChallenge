using System;
using UnityEngine;

public class InputsHandler : MonoBehaviour
{
    public event Action OnInstantiateAnchor;
    public event Action<string,bool> OnRoomSizeOpen;

    private void Update()
    {    
        // Instantiate Anchors
        if (Input.GetKeyDown(KeyCode.F))
        {
            OnInstantiateAnchor?.Invoke();
        }

        //Open room size menu
        if (Input.GetKeyDown(KeyCode.C))
        {
            OnRoomSizeOpen?.Invoke("RoomSize",true);
        }
    }
}
