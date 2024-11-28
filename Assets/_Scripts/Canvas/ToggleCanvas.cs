using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ToggleCanvas : MonoBehaviour
{
    [Inject] private CanvasHandler canvasHandler;
    [SerializeField] private string canvasName;
    [SerializeField] private bool activate;

    private void Awake()
    {
        transform.GetComponent<Button>().onClick.AddListener(Toggle);
    }

    public void Toggle() 
    {
        canvasHandler.ToggleCanvas(canvasName, activate);
    }
}
