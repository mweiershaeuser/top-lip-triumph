using SupanthaPaul;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{

    // public PlayerController playerController;
    public SaveData saveData;
    public static SaveController Instance;
    private string savePath;

    private bool loaded = false;

    private void Start()
    {
        savePath = Application.persistentDataPath + "/saveData.json";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.F9))
        {
            RefreshPlayerController();
        }
    }

    public void SaveGame()
    {
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        // TODO: Now it won't work, fix it
            playerController.WriteToSaveData(this.saveData);

        saveData.currentLevelName = SceneManager.GetActiveScene().name;
        string json = JsonUtility.ToJson(this.saveData);
        File.WriteAllText(savePath, json);
        Debug.Log("Game data saved");
    }

    public void LoadGameFromFile()
    {
        this.loaded = true;
        if (File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);
            this.saveData = JsonUtility.FromJson<SaveData>(jsonData);
            // PlayerController playerController = FindObjectOfType<PlayerController>();
            // Debug.Log("Loaded game data");
            // playerController.LoadFromSaveData(this.saveData);
        }
        else
        {
            this.saveData = new SaveData();
            Debug.Log("No saved game data found.");
        }
    }

    public void RefreshPlayerController()
    {
        PlayerController playerController = FindObjectOfType<PlayerController>();
        Debug.Log("Loaded game data");
        playerController.LoadFromSaveData(this.saveData);
    }

    private void Awake()
    {
        // Ensure there's only one instance of the GameManager
        if (Instance == null)
        {
            Debug.Log("Loaded path 1");
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("Loaded path 2");
            Destroy(gameObject);
        }

        Debug.Log("Loaded path 3");
        // Initialize the SaveData instance
        // TODO: load from save
        saveData = new SaveData();
    }

    public void LoadScene(string levelName)
    {
        if (saveData.openedLevels.Contains(levelName))
        {
            saveData.openedLevels.Add(levelName);
        }

        // SaveGame();
        SceneManager.LoadScene(levelName);
    }

    public bool IsLoaded()
    {
        return this.loaded;
    }
}
