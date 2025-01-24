using TMPro;
using UnityEngine;

public abstract class IntToTextDisplay : MonoBehaviour, IUIDisplay<int>
{

    [SerializeField] private TextMeshProUGUI _textDisplay;
    [SerializeField] private string _preItemText;
    [SerializeField] private string _PostItemText;
    public void Display(int displayItem)
    {

        _textDisplay.text = (_preItemText + displayItem + _PostItemText);
    }

    public abstract void Enable();
    public abstract void Disable();

    protected virtual void OnEnable()
    {
        Enable();
    }

    protected virtual void OnDisable()
    {

        Disable();

    }
}
