using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
    public GameObject ui;
    public GameObject pause;
    public GameObject ingame;
    public GameObject settings;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
    }

    public void PauseMenu()
    {
        ingame.SetActive(!ingame.activeSelf);
        pause.SetActive(!pause.activeSelf);
        settings.SetActive(false);

        if (pause.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void SettingsMenu()
    {
        settings.SetActive(!settings.activeSelf);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }    

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }    
}
