using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LoadSceneButton : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] int _levelIndex;
    [Inject] SceneLoader _sceneLoader;
    // Start is called before the first frame update
    void Start()
    {
        _button.onClick.AddListener(ButtonClicked);
    }

    void ButtonClicked()
    {
        _sceneLoader.LoadSceneByIndex(_levelIndex);
    }
}
