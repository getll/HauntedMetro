using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject lights;
    public float loadSceneAfterSeconds = 3.0f;
    public float shutLightsAfterSeconds = 1.0f;
    public string sceneName = "NextScene";

    void Start()
    {
        Invoke("ShutLightOff", shutLightsAfterSeconds);
        Invoke("LoadScene", loadSceneAfterSeconds);
    }

    void ShutLightOff()
    {
        lights.SetActive(false);
        RenderSettings.fogDensity = 0.80f;
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
