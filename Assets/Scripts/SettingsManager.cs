using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    bool paused = false;
    public GameObject pauseMenu;
    public GameObject settingsObj;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;

        pauseMenu = GameObject.Find("PauseMenu");
        settingsObj = GameObject.Find("SettingsMenu");

        if (pauseMenu) pauseMenu.SetActive(false);
        if (settingsObj) settingsObj.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu){
            
            //if settings is active, hide settings
            if (settingsObj.activeSelf)
            {
                HideSettings();
            }
            else{
                // ESC = toggle settings ON/OFF
                PauseGame();
            }
        }
    }

    // change scene to main menu scene
    public void MainMenu()
    {
        // add transition here?
        SceneManager.LoadScene("Main Menu");
    }

    // toggle gamepause
    public void PauseGame()
    {
        // toggle the pausedMenu
        paused = !paused;

        if(!paused)
        {
            settingsObj.SetActive(false);
            Time.timeScale = 1; // restore timescale
        }
        else {
            Time.timeScale = 0; // stop time
        }

        pauseMenu.SetActive(paused);
    }

    // toggle settings
    public void ShowSettings()
    {
        settingsObj.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void HideSettings()
    {
        settingsObj.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}