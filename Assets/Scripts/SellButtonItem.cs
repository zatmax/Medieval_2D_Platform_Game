using UnityEngine;
using UnityEngine.UI;

public class SellButtonItem : MonoBehaviour
{
    public Image itemImage;
    public Text itemPrice;
    //public AudioClip soundToPlay;
    //public AudioClip sound_nok;

    //public Text itemName;

    public Item item;

    public void BuyItem()
    {
        Inventory inventory = Inventory.instance;   //permet de remplacer inventory.instance (plus court)
        if(inventory.coinsCount >= item.price)
        {
            //AudioManager.instance.PlayClipAt(soundToPlay, transform.position);
            inventory.content.Add(item);
            inventory.UpdateInventoryUI();
            inventory.coinsCount -= item.price;
            inventory.UpdateTextUI();
        }
        /**else
        {
            AudioManager.instance.PlayClipAt(sound_nok, transform.position);
        }**/
    }
}