using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;
    //public Text coinsPickedUpInThisSceneCount;

    public GameObject InventoryUI;

    public static bool InventoryIsClosed = false;

    public List<Item> content = new List<Item>();

    private int contentCurrentIndex = 0;

    public Image itemImageUI;
    public Sprite emptyItemImage;
    public Text itemNameUI;

    public PlayerEffects playerEffects;

    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Inventory dans la scène");
            return;
        }
        instance = this;
    }
    //tentative de faire apparaitre le nombre de piece sur le panneau gameover
    //MenuCountCoins.text = CurrentSceneManager.instance.coinsPickedUpInThisSceneCount.ToString();
    
    private void Start()
    {
        UpdateInventoryUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InventoryIsClosed)
            {
                Open();
            }
            else
            {
                Close();
            }
        }
    }

    void Open()
    {
        InventoryUI.SetActive(true);
        InventoryIsClosed = false;
    }

    public void Close()
    {
        InventoryUI.SetActive(false);
        InventoryIsClosed = true;
    }


    public void ConsumeItem()
    {
        if(content.Count == 0)
        {
            return;
        }
        Item currentItem = content[contentCurrentIndex];
        PlayerHealth.instance.HealPlayer(currentItem.hpGiven);
        playerEffects.AddSpeed(currentItem.speedGiven, currentItem.speedDuration);
        playerEffects.AddJump(currentItem.JumpGiven, currentItem.jumpDuration);
        content.Remove(currentItem);
        GetNextItem();
        UpdateInventoryUI();
    }

    public void GetNextItem()
    {
        if(content.Count == 0)
        {
            return;
        }
        contentCurrentIndex++;

        if(contentCurrentIndex > content.Count - 1)
        {
            contentCurrentIndex = 0;
        }
        UpdateInventoryUI();
    }

    public void GetPreviousItem()
    {
        if(content.Count == 0)
        {
            return;
        }
        contentCurrentIndex--;

        if(contentCurrentIndex < 0)
        {
            contentCurrentIndex = content.Count - 1;
        }
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        if (content.Count > 0)
        {
            itemImageUI.sprite = content[contentCurrentIndex].image;
            itemNameUI.text = content[contentCurrentIndex].name;
        }
        else
        {
            itemImageUI.sprite = emptyItemImage;
            itemNameUI.text = "";
        }
        
    }

        public void AddCoins(int count)
    {
        coinsCount += count;
        UpdateTextUI();
    }

    public void RemoveCoins(int count)
    {
        coinsCount -= count;
        UpdateTextUI();
    }

    public void UpdateTextUI()
    {
        coinsCountText.text = coinsCount.ToString();
    }
}
