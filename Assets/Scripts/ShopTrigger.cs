using UnityEngine;
using UnityEngine.UI;

public class ShopTrigger : MonoBehaviour
{
    public bool isInRange;

    private Text interactUI;

    public AudioClip sound;

    public string pnjName;
    public Item[] itemsToSell;

    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            AudioManager.instance.PlayClipAt(sound, transform.position);
            ShopManager.instance.OpenShop(itemsToSell, pnjName);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            interactUI.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            interactUI.enabled = false;
            ShopManager.instance.CloseShop();
        }
    }
}
