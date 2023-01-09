using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpener : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject optionsPanel;

    // Update is called once per frame
    void Update()
    {
        // Check if the escape key has been pressed
        if (Input.GetKeyDown(KeyCode.Escape) && !optionsPanel.activeSelf)
        {
            // Toggle the active state of the options panel
            menuPanel.SetActive(!menuPanel.activeSelf);

            // If the options panel is now active, freeze the time of the game
            // If the options panel is now inactive, resume the time of the game
            Time.timeScale = menuPanel.activeSelf ? 0 : 1;
            
            Cursor.lockState = menuPanel.activeSelf ? CursorLockMode.None : CursorLockMode.Locked;
            
            Cursor.visible = menuPanel.activeSelf;

            // Reset the input values for the camera
            if (menuPanel.activeSelf)
            {
                Input.ResetInputAxes();
            }

            AudioListener.pause = menuPanel.activeSelf;
        }
    }
}
