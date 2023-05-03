using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public float loadSceneAfterSeconds = 2.0f;
    public string sceneName = "NextScene";

    void Start()
    {
        Invoke("LoadScene", loadSceneAfterSeconds);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
