using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanelFader : MonoBehaviour
{
    public CanvasGroup menuPanel;
    public float fadeDuration = 1.0f;

    void Start()
    {
        // Fade in the menu panel
        StartCoroutine(FadeIn(menuPanel, fadeDuration));
    }
    
    IEnumerator FadeIn(CanvasGroup canvasGroup, float duration)
    {
        // Set the initial alpha to 0
        canvasGroup.alpha = 0;

        // Fade in over the specified duration
        yield return Fade(canvasGroup, 0, 1, duration);
    }

    IEnumerator Fade(CanvasGroup canvasGroup, float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            // Calculate the current alpha
            float currentAlpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            canvasGroup.alpha = currentAlpha;

            // Increment the elapsed time and wait for the next frame
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
