using UnityEngine;

public class PlayerPrefsReset : MonoBehaviour
{
    // Attach this method to a button click or UI event in the Unity Editor
    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("PlayerPrefs have been reset.");
    }
}