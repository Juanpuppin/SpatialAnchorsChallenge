using System;
using UnityEngine;
using Zenject;

public class Room : MonoBehaviour
{
    // Show in inspector
    [SerializeField] private Vector2 roomDimensions = new Vector2 (1,1);

    [Header("Tiles")]   
    [SerializeField] private int tilesResolution = 1;
    [Space]
    [SerializeField] private MeshRenderer floor;
    [SerializeField] private MeshRenderer[] frontAndBackWalls = null;
    [SerializeField] private MeshRenderer[] leftAndRightWalls = null; 

    //Public
    public event Action<Vector2> OnUpdateRoomDimensions;

    private void Awake()
    {
        UpdateRoomDimensions();
    }

    [EditorCools.Button]
    public void UpdateRoomDimensions() 
    {
        transform.localScale = new Vector3(roomDimensions.x, transform.localScale.y, roomDimensions.y);

        floor.material.mainTextureScale = roomDimensions * tilesResolution;

        // Set walls tiles
        foreach (MeshRenderer _roomMaterial in frontAndBackWalls) 
        {
            _roomMaterial.material.mainTextureScale = new Vector2(1, roomDimensions.x) * tilesResolution;           
        }
        foreach (MeshRenderer _roomMaterial in leftAndRightWalls)
        {
            _roomMaterial.material.mainTextureScale = new Vector2(1, roomDimensions.y) * tilesResolution;
        }

        OnUpdateRoomDimensions?.Invoke(roomDimensions);
    }
}
