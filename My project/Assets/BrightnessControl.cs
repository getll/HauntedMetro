using UnityEngine;
using UnityEngine.UI;

public class BrightnessControl : MonoBehaviour
{
    public Slider brightnessSlider;

    void Start()
    {
        if (PlayerPrefs.HasKey("Brightness"))
        {
            brightnessSlider.value = PlayerPrefs.GetFloat("Brightness");
            SetBrightness();
        }

    }

    public void SetBrightness()
    {
        RenderSettings.ambientLight = new Color(brightnessSlider.value, brightnessSlider.value, brightnessSlider.value, 1.0f);

        PlayerPrefs.SetFloat("Brightness", brightnessSlider.value);
        PlayerPrefs.Save();

    }
}
