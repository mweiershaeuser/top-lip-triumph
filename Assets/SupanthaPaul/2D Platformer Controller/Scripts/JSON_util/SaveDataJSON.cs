using SupanthaPaul;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveDataJSON : MonoBehaviour
{

    public PlayerController playerController;

    private string savePath;

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
            LoadGame();
        }
    }

    public void SaveGame()
    {
        string json = JsonUtility.ToJson(playerController);
        File.WriteAllText(savePath, json);
        Debug.Log("Game data saved");
    }

    public void LoadGame()
    {
        if (File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);
            PlayerSaveData data = JsonUtility.FromJson<PlayerSaveData>(jsonData);
            Debug.Log("Loaded game data");
            playerController.LoadFromSaveData(data);
        }
        else
        {
            Debug.Log("No saved game data found.");
        }
    }


}
