using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIinitializer : MonoBehaviour
{
    public GameObject slider;
    public GameObject mainMenu;
    public GameObject optionsMenu;

    // Start is called before the first frame update
    void Start()
    {
        slider.SetActive(true);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
