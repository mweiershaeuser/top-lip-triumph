using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionsMenu;

    void Start()
    {
        ShowMainMenu();
    }

    public void Play()
    {
        SceneManager.LoadScene("PlayTest");
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
}
