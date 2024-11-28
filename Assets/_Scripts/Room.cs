using System;
using UnityEngine;
using Zenject;

public class Room : MonoBehaviour
{
    // Show in inspector  
    [Header("Tiles")]   
    [SerializeField] private int tilesResolution = 1;
    [Space]
    [SerializeField] private MeshRenderer floor;
    [SerializeField] private MeshRenderer[] frontAndBackWalls = null;
    [SerializeField] private MeshRenderer[] leftAndRightWalls = null; 

    //Public
    public event Action<Vector2> OnUpdateRoomDimensions;
    public Vector2 roomDimensions = new Vector2(10, 10);

    //Private
    private float resolutionAdjustment = 2;

    private void Awake()
    {
        UpdateRoomDimensions();
    }

    [EditorCools.Button]
    public void UpdateRoomDimensions() 
    {
        transform.localScale = new Vector3(roomDimensions.x / 10, transform.localScale.y, roomDimensions.y / 10);

        floor.material.mainTextureScale = roomDimensions * tilesResolution;

        TileTexture();
    }

    public void UpdateRoomDimensions(Vector2 insertedDimensions)
    {
        transform.localScale = new Vector3(insertedDimensions.x/10, transform.localScale.y, insertedDimensions.y / 10);
        roomDimensions = insertedDimensions;
        TileTexture();
    }

    private void TileTexture()
    {
        floor.material.mainTextureScale = roomDimensions * tilesResolution / resolutionAdjustment;

        // Set walls tiles
        foreach (MeshRenderer _roomMaterial in frontAndBackWalls)
        {
            _roomMaterial.material.mainTextureScale = new Vector2(1, roomDimensions.x / resolutionAdjustment) * tilesResolution;
        }
        foreach (MeshRenderer _roomMaterial in leftAndRightWalls)
        {
            _roomMaterial.material.mainTextureScale = new Vector2(1, roomDimensions.y/ resolutionAdjustment) * tilesResolution;
        }

        OnUpdateRoomDimensions?.Invoke(roomDimensions);
    }
}
