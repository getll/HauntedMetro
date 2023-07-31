using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPanel : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject optionsPanel;
    
    public void ReturntoTitle()
    {
        SceneManager.LoadScene("TitleScreen");

        Time.timeScale = 1;

        AudioListener.pause = false;
    }

    public void ResumeButton()
    {
        menuPanel.SetActive(false);
        
        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;

        Time.timeScale = 1;

        AudioListener.pause = false;
    }

    public void OptionsButton()
    {
        menuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
