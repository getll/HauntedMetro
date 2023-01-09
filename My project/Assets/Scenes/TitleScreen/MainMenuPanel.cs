using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPanel : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject optionsmenu;

    // Start is called before the first frame update
    void Start()
    {
        mainmenu.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Gamescene");
    }

    public void GoToOptions()
    {
        mainmenu.SetActive(false);
        optionsmenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
