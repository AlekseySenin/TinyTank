using UnityEngine.SceneManagement;
public class SceneLoader
{
    public void LoadSceneByIndex(int sceneIndex) 
    { 
        SceneManager.LoadScene(sceneIndex); 
    }
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
