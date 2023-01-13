using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public float fadeInDuration = 2.0f;
    public float displayDuration = 3.0f;
    public float fadeOutDuration = 2.0f;

    public CanvasGroup logoGroup;
    public CanvasGroup textGroup;
    public CanvasGroup mouseGroup;

    void Start()
    {
        StartCoroutine(ShowSplashScreen());
    }

    IEnumerator ShowSplashScreen()
    {
        // Fade in
        logoGroup.alpha = 0.0f;
        textGroup.alpha = 0.0f;
        mouseGroup.alpha = 0.0f;
        float t = 0.0f;
        while (t < 1.0f)
        {
            t += Time.deltaTime / fadeInDuration;
            logoGroup.alpha = Mathf.Lerp(0.0f, 1.0f, t);
            textGroup.alpha = Mathf.Lerp(0.0f, 1.0f, t);
            yield return null;
        }

        // Display logo and text
        t = 0.0f;
        while (t < 1.0f)
        {
            t += Time.deltaTime / displayDuration;
            yield return null;
        }

        mouseGroup.alpha = 1.0f;

        // Wait for user input
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }

        // Fade out
        t = 0.0f;
        while (t < 1.0f)
        {
            t += Time.deltaTime / fadeOutDuration;
            logoGroup.alpha = 1.0f - Mathf.Lerp(0.0f, 1.0f, t);
            textGroup.alpha = 1.0f - Mathf.Lerp(0.0f, 1.0f, t);
            mouseGroup.alpha = 1.0f - Mathf.Lerp(0.0f, 1.0f, t);
            yield return null;
        }

        // Load next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

