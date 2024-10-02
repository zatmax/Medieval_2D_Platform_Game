using UnityEngine;
using System.Linq;
public class LoadAndSaveData : MonoBehaviour
{
    

    public static LoadAndSaveData instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de public static CurrentSceneManager instance; dans la scène");
            return;
        }
        instance = this;
    }

    void Start()
    {
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("coinsCount", 0);
        Inventory.instance.UpdateTextUI();

        //charge element inventaire
        string[] itemsSaved = PlayerPrefs.GetString("inventoryItems").Split(',');

        for (int i = 0; i < itemsSaved.Length; i++)
        {
            if(itemsSaved[i] != "")
            {
                int id = int.Parse(itemsSaved[i]);  //transforme string --> int
                Item currentItem = ItemsDatabase.instance.allItems.Single(x => x.id == id); //sql
                Inventory.instance.content.Add(currentItem);
            }
        }
        //maj UI
        Inventory.instance.UpdateInventoryUI();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("coinsCount", Inventory.instance.coinsCount);

        if(CurrentSceneManager.instance.levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", CurrentSceneManager.instance.levelToUnlock);
        }

        string itemsInInventory = string.Join(",", Inventory.instance.content.Select(x => x.id));   //comme en sql
        PlayerPrefs.SetString("inventoryItems", itemsInInventory);

        
    }
}

