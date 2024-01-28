using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Canvas canvas;
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public TextMeshProUGUI musicLabel;
    public TextMeshProUGUI sfxLabel;
    public bool isPauseMenu;

    void Start()
    {
        if (isPauseMenu)
        {
            canvas.enabled = false;
        }
        ShowMainMenu();
        DisplayMusicState();
        DisplaySFXState();
    }

    void Update()
    {
        if (isPauseMenu)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                canvas.enabled = !canvas.enabled;
            }
        }
    }

    public void Play()
    {
        if (isPauseMenu)
        {
            canvas.enabled = !canvas.enabled;
        }
        else
        {
            SceneManager.LoadScene("Dialogue01");
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ShowMainMenu()
    {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }

    public void ShowOptionsMenu()
    {
        OptionsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void ToggleMusic()
    {
        AudioManager.global.ToggleMusic();
        DisplayMusicState();
    }

    private void DisplayMusicState()
    {
        if (AudioManager.global.musicSource.mute)
        {
            musicLabel.text = "Music off";
        }
        else
        {
            musicLabel.text = "Music on";
        }
    }

    public void ToggleSFX()
    {
        AudioManager.global.ToggleSFX();
        DisplaySFXState();
    }

    private void DisplaySFXState()
    {
        if (AudioManager.global.sfxSource.mute)
        {
            sfxLabel.text = "SFX off";
        }
        else
        {
            sfxLabel.text = "SFX on";
        }
    }
}
