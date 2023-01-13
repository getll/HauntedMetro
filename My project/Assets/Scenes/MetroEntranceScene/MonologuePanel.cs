using UnityEngine;
using TMPro;

public class MonologuePanel : MonoBehaviour
{
    public TMP_Text[] sentences;
    private int currentSentence;
    public CanvasGroup mouseGif;
    public CanvasGroup monologuePanel;

    public GameObject slider;
    public GameObject mainMenu;
    public GameObject optionsMenu;

    void Start()
    {
        slider.SetActive(false);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        
        sentences[0].alpha = 0;
        sentences[1].alpha = 0;
        sentences[2].alpha = 0;
        mouseGif.alpha = 0;

        currentSentence = 0;

        FadeIn(currentSentence);
        mouseGif.alpha = 1;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseGif.alpha = 0;
            currentSentence++;
            if (currentSentence < sentences.Length)
            {
                FadeIn(currentSentence);
                mouseGif.alpha = 1;
            }

            if (currentSentence == 3)
            {
                FadeOut(monologuePanel);
            }
        }
    }

    void FadeIn(int index)
    {
        sentences[index].enabled = true;
        LeanTween.value(sentences[index].gameObject, 0, 1, 4).setOnUpdate((float val) => { sentences[index].alpha = val; });
    }

    void FadeOut(CanvasGroup obj)
    {
        slider.SetActive(true);
        
        LeanTween.value(obj.gameObject, 1, 0, 2).setOnUpdate((float val) => { obj.alpha = val; }).setOnComplete(() => { obj.gameObject.SetActive(false); });
    }
}
