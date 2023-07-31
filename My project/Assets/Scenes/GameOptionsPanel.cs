using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOptionsPanel : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject menuPanel;

    public Slider volumeSlider;
    public AudioSource audioSource;

    public FirstPersonController firstPersonController;
    public Slider mouseSensitivitySlider;

    public Toggle fullscreenToggle;

    public TMPro.TMP_Dropdown graphicsDropdown;

    // Start is called before the first frame update
    void Start()
    {
        // Load the saved volume level from PlayerPrefs
        volumeSlider.value = PlayerPrefs.GetFloat("VolumeLevel", 1.0f);

        // Set the initial value of the slider to the current mouse sensitivity
        mouseSensitivitySlider.value = PlayerPrefs.GetFloat("Mouse Sensitivity", 1.0f);
    }

    public void UpdateMouseSensitivity()
    {
        // Get the current value of the slider
        float sensitivity = mouseSensitivitySlider.value;

        // Update the mouse sensitivity in the FirstPersonController script
        firstPersonController.SetMouseSensitivity(sensitivity);

        // Save the sensistivity level to PlayerPrefs
        PlayerPrefs.SetFloat("Mouse Sensitivity", mouseSensitivitySlider.value);
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

    public void returnToMenuPanel()
    {
        optionsPanel.SetActive(false);
        menuPanel.SetActive(true);
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
}
