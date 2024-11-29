using System;
using UnityEngine;
using Zenject;

public class Anchor : MonoBehaviour
{
    //static
    private static event Action OnAnchorChange;
    public static Anchor CurrentNearestAnchor;

    //Inject
    [Inject] private Room room;
    [Inject] private AnchorsHandler anchorsHandler;
    [Inject] private FreeFlyCamera freeFlyCamera;

    //Private
    private Vector3 anchoredPosition;
    private float distanceFromPlayer;
    private MeshRenderer meshRender;

    //Public
    public float Distance;
    public float AnchorReach = 10;

    private void OnEnable()
    {
        room.OnUpdateRoomDimensions += UpdateAnchorPosition;
        anchorsHandler.OnCheckDistances += SearchNearestAnchor;
        OnAnchorChange += ToggleColor;
        meshRender = transform.GetComponent<MeshRenderer>();
    }

    private void OnDisable()
    {
        room.OnUpdateRoomDimensions -= UpdateAnchorPosition;
        anchorsHandler.OnCheckDistances -= SearchNearestAnchor;
        OnAnchorChange -= ToggleColor;
    }

    //Anchoring
    public void StoreLocalPosition() 
    {
        anchoredPosition = transform.localPosition;
    }

    private void UpdateAnchorPosition(Vector2 _roomDimensions)
    {
        Vector3 _newPosition = new Vector3(anchoredPosition.x * (_roomDimensions.x/10), anchoredPosition.y, anchoredPosition.z * (_roomDimensions.y/10));
        transform.localPosition = _newPosition;
    } 

    private void SearchNearestAnchor()
    {
        distanceFromPlayer = CalculateDistanceFromPlayer();

        if (CurrentNearestAnchor == null || distanceFromPlayer < CurrentNearestAnchor.distanceFromPlayer & distanceFromPlayer < AnchorReach)
        {
            CurrentNearestAnchor = this;
            OnAnchorChange?.Invoke();
        }
    }

    private float CalculateDistanceFromPlayer() 
    {
        Distance = Vector3.Distance(transform.position, freeFlyCamera.transform.position);        
        return Distance;
    }

    private void ToggleColor()
    {
        if (CurrentNearestAnchor == this)
        {
            meshRender.material.color = Color.green;         
        }
        else
        {
            meshRender.material.color = Color.red;           
        }
    }
}
