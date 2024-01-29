using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] collectableItems;

    private void Start()
    {
        LoadCollectedItems();
        SaveData saveData = SaveController.Instance.saveData;
        Debug.Log(saveData);
    }

    void LoadCollectedItems()
    {
        foreach (GameObject item in collectableItems)
        {
            string itemName = item.GetComponent<CollectableCoin>().itemId;
            int collected = PlayerPrefs.GetInt(itemName + "_Collected", 0);

            if (collected == 1)
            {
                // Item has been collected, disable it
                item.SetActive(false);
            }
        }
    }
}