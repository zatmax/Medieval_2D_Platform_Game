using UnityEngine;
using UnityEngine.UI;

public class Lader : MonoBehaviour
{
    private bool isInRange;
    private PlayerMovement playerMovement;
    //public BoxCollider2D topCollider;
    private Text interactUI;

    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void Update()
    {
        //pb pour sortir de l'échelle une fois appuyé sur E
        if(playerMovement.isClimbing && isInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = false;
            //topCollider.isTrigger = false;
            return;
        }

        if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = true;
            //topCollider.isTrigger = true;
            interactUI.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            playerMovement.isClimbing = false;
            //topCollider.isTrigger = false;
            interactUI.enabled = false;
        }
    }
}
