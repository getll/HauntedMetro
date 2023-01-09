using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject optionsPanel;

    // Start is called before the first frame update
    void Start()
    {
        menuPanel.SetActive(false);    
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
