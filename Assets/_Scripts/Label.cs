using UnityEngine;

public class Label : MonoBehaviour
{
    public void PlaceLabel(Anchor _anchor)
    {
        transform.position = _anchor.transform.position;
    }
}
