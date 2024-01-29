using System.Collections;
using System.Collections.Generic;
using SupanthaPaul;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelCollectable : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform respawnPoint;
     [SerializeField]
    public string NextLevel;

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("Player"))
        {
            Debug.Log("Collides 1");
            TransitLevel();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Collides 2");
            TransitLevel();
        }
    }

    void TransitLevel()
    {
        PlayerController playerController = FindObjectOfType<PlayerController>();

        if (playerController != null)
        {
            // Make the player jump three times
            playerController.Jump();
            // TODO: make it wait till Jump ends, or just some fancy animation

            // I need it to check if it's proper level and we should reset coordinates, or smth random
            SaveController.Instance.saveData.positionIsValid = false;
            SceneManager.LoadScene(NextLevel);
            SaveController.Instance.SaveGame();
        }
    }
}
