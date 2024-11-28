using UnityEngine;
using UnityEngine.UI;
using Zenject;
using TMPro;


public class RoomDimensionsUI : MonoBehaviour
{
    // Inject
    [Inject] private Room room;

    // Visible in Inspector
    [SerializeField] private Button applyButton;
    [SerializeField] private TMP_InputField width, length;

    private void Start()
    {
        applyButton.onClick.AddListener(ApplyNewDimensions);     
    }

    private void OnEnable()
    {
        width.text = room.roomDimensions.x.ToString("F0");
        length.text = room.roomDimensions.y.ToString("F0");
    }

    private void ApplyNewDimensions()
    {
        if (int.TryParse(width.text, out int widthMeters) && int.TryParse(length.text, out int lengthMeters))
        {
            room.UpdateRoomDimensions(new Vector2(widthMeters, lengthMeters));
        }
    }
}

