using System;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class Anchor : MonoBehaviour
{
    private static event Action OnAnchorChange;
    private static Anchor CurrentNearestAnchor;

    //Inject
    [Inject] private Room room;
    [Inject] private AnchorsHandler anchorsHandler;
    [Inject] private FreeFlyCamera freeFlyCamera;
    [Inject] private Label label;

    //Private
    private Vector3 anchoredPosition;
    private float distanceFromPlayer;
    private MeshRenderer meshRender;

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
        Vector3 _newPosition = new Vector3(anchoredPosition.x * _roomDimensions.x, anchoredPosition.y, anchoredPosition.z * _roomDimensions.y);
        transform.localPosition = _newPosition;
    } 

    private void SearchNearestAnchor()
    {
        distanceFromPlayer = CalculateDistanceFromPlayer();

        if (CurrentNearestAnchor == null || distanceFromPlayer < CurrentNearestAnchor.distanceFromPlayer)
        {
            CurrentNearestAnchor = this;
            OnAnchorChange?.Invoke();
        }
    }

    private float CalculateDistanceFromPlayer() 
    {
        float _distance = Vector3.Distance(transform.position, freeFlyCamera.transform.position);        
        return _distance;
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
