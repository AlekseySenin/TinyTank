using UnityEngine;
using Zenject;

public class BootObject : MonoBehaviour
{
    [Inject] SceneLoader _sceneLoader;
    // Start is called before the first frame update
    void Start()
    {
        _sceneLoader.LoadSceneByIndex(1);
    }
}
