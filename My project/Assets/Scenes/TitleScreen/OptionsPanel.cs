using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPanel : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject mainmenuPanel;

    public Slider volumeSlider;
    public AudioSource audioSource;

    public Slider mouseSensitivitySlider;

    public Toggle fullscreenToggle;

    public TMPro.TMP_Dropdown graphicsDropdown;

    // Start is called before the first frame update
    void Start()
    {
        // Options Panel is set to inactive when the Title Screen is loaded
        optionsPanel.SetActive(false);

        // Load the saved volume level from PlayerPrefs
        volumeSlider.value = 0.20f;

        // Set the initial value of the slider to the current mouse sensitivity
        mouseSensitivitySlider.value = 1.0f;
        PlayerPrefs.SetFloat("Mouse Sensitivity", 1.0f);
    }

    public void OnVolumeChanged()
    {
        // Set the volume of the audio source to the value of the volume slider
        audioSource.volume = volumeSlider.value;

        // Save the volume level to PlayerPrefs
        PlayerPrefs.SetFloat("VolumeLevel", volumeSlider.value);
    }

    public void goFullScreen()
    {
        Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void returnToTitleScreen()
    {
        optionsPanel.SetActive(false);
        mainmenuPanel.SetActive(true);
    }

    public void GraphicsSettings()
    {
        switch (graphicsDropdown.value)
        {
            case 0:
            QualitySettings.masterTextureLimit = 0;
            QualitySettings.antiAliasing = 0;
            break;

            case 1:
            QualitySettings.masterTextureLimit = 1;
            QualitySettings.antiAliasing = 2;
            break;

            case 2:
            QualitySettings.masterTextureLimit = 2;
            QualitySettings.antiAliasing = 4;
            break;
        }
    }

    public void UpdateMouseSensitivity()
    {
        // Update the mouse sensitivity in the FirstPersonController script
        PlayerPrefs.SetFloat("Mouse Sensitivity", mouseSensitivitySlider.value);
    }
}
