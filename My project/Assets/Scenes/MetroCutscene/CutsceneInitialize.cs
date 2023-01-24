using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneInitialize : MonoBehaviour
{
    public GameObject fadePanel;
    public GameObject menuPanel;
    public GameObject optionsMenu;
    public float fadeOutDuration = 1f; // add a variable to control the fade out duration

    // Start is called before the first frame update
    void Start()
    {
        menuPanel.SetActive(false);
        optionsMenu.SetActive(false);
        StartCoroutine(FadeOut()); // call the coroutine to fade out the panel
    }

    IEnumerator FadeOut()
    {
        CanvasGroup canvasGroup = fadePanel.GetComponent<CanvasGroup>();
        fadePanel.SetActive(true);
        float currentTime = 0f;
        float originalAlpha = canvasGroup.alpha;
        float fadedAlpha = 0f;
        while (currentTime < fadeOutDuration)
        {
            currentTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(originalAlpha, fadedAlpha, currentTime / fadeOutDuration);
            yield return null;
        }
        canvasGroup.gameObject.SetActive(false);
    }
}

