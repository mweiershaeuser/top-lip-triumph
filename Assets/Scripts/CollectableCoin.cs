using System.Collections;
using System.Collections.Generic;
using SupanthaPaul;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectableCoin : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform respawnPoint;
     [SerializeField]
    public string NextLevel;
    public string itemId;
    public string level;

    void Start()
    {// Generate a unique ID based on the GameObject's name
        itemId = gameObject.name.Replace(" ", ""); // Remove spaces for simplicity
        level = SceneManager.GetActiveScene().name;

        // Check if the item has been collected before
        if (SaveController.Instance.saveData.collectedItems.Contains(level + itemId + "_Collected"))
        {
            // Item has been collected, disable it
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("Player"))
        {
            Debug.Log("Collides 1");
            Collect();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Collides 2");
            Collect();
        }
    }

    void Collect()
    {
        PlayerController playerController = FindObjectOfType<PlayerController>();

        if (playerController != null)
        {
            playerController.Collect();
            // PlayerPrefs.SetInt(itemId + "_Collected", 1);
            SaveController.Instance.saveData.collectedItems.Add(level + itemId + "_Collected");
            gameObject.SetActive(false);
        }
    }
}

