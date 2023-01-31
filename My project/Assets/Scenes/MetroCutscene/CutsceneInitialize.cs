using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneInitialize : MonoBehaviour
{
    public GameObject fadePanel;
    public GameObject menuPanel;
    public GameObject optionsMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        menuPanel.SetActive(false);
        optionsMenu.SetActive(false);
    }
}

