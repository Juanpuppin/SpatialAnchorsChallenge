using UnityEngine;
using Zenject;
using TMPro;

public class Label : MonoBehaviour
{
    //Inject
    [Inject] FreeFlyCamera freeFlyCamera;

    //View in inspector
    [SerializeField] GameObject label;
    [SerializeField] TextMeshPro labelText;
    [SerializeField] Vector3 positionOffset;

    //private
    private Anchor selectedAnchor;

    private void Start()
    {
        label.SetActive(false);
    }

    private void Update()
    {
        if (label.activeSelf)
        {
            FaceCamera();
            UpdateLabelText();
        }
    }

    private void FaceCamera()
    {
        Vector3 directionToCamera = transform.position - freeFlyCamera.CameraRef.transform.position;
        transform.rotation = Quaternion.LookRotation(directionToCamera);

        float distance = directionToCamera.magnitude;
        float scaleFactor = Mathf.Clamp(distance * 0.03f, 0.03f, 1f);

        transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
    }

    private void UpdateLabelText()
    {
        float distanceInMeters = selectedAnchor.Distance; // Assuming distance is in meters.
        string formattedDistance;

        if (distanceInMeters < 1.0f)
        {
            // centimeter
            formattedDistance = (distanceInMeters * 100f).ToString("F0") + " cm";
        }
        else
        {
            // meters
            formattedDistance = distanceInMeters.ToString("F2") + " m";
        }

        labelText.text = formattedDistance;
    }

    public void UpdateLabelPosition(Anchor _anchor)
    {
        if (_anchor == Anchor.CurrentNearestAnchor)
        {
            transform.position = _anchor.transform.position + positionOffset;
            selectedAnchor = _anchor;
            label.SetActive(true);
        }
        else
        {
            label.SetActive(false);
        }
    }

    public void DeactivateLabel() 
    {
        label.SetActive(false);
    }
}
