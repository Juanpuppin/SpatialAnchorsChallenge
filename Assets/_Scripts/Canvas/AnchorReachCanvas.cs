using UnityEngine;
using UnityEngine.UI;
using Zenject;
using TMPro;

public class AnchorReachCanvas : MonoBehaviour
{  
    // Visible in Inspector
    [SerializeField] private Button applyButton;
    [SerializeField] private TMP_InputField reach;

    private Anchor currentAnchor;

    private void Start()
    {
        applyButton.onClick.AddListener(UpdateAnchorReach);
    }

    public void SetAnchorReach(Anchor _anchor)
    {
        reach.text = _anchor.AnchorReach.ToString("F0");
        currentAnchor = _anchor;
    }

    private void UpdateAnchorReach()
    {
        if (int.TryParse(this.reach.text, out int reach))
        {
            currentAnchor.AnchorReach = reach;
        }
    }
}
