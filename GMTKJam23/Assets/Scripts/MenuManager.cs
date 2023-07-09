using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject exitPanel;
    public GameObject controlPanel;

    public GameObject transtion;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitPanel.SetActive(true);
        }
    }

    public void Play()
    {
        transtion.SetActive(true);
    }

    public void ControlPanel()
    {
        settingsPanel.SetActive(false);
        controlPanel.SetActive(true);
    }

    public void ExitControlPanel()
    {
        controlPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void SettingsPanel()
    {
        settingsPanel.SetActive(true);
    }

    public void DisablePanel()
    {
        settingsPanel.SetActive(false);
        exitPanel.SetActive(false);
    }

  

    public void Quit()
    {
        Application.Quit();
    }

    
}
