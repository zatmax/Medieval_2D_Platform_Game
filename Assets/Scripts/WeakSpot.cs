using UnityEngine;
using System.Collections;

public class WeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;
    public Animator animator;
    public BoxCollider2D slimeCollider;
    public AudioClip killSound;
    public SpriteRenderer graphics;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //attention risque pb ici, allocation box collider dans inspector impossible à déposer, fait par recherche
            slimeCollider.enabled = false;
            AudioManager.instance.PlayClipAt(killSound, transform.position);
            StartCoroutine(DeathDelay());
            //revenir sur erreur instance ici plus tard
        }
    }

    public IEnumerator DeathDelay()
    {
        animator.SetTrigger("Death");
        yield return new WaitForSeconds(0.8f);
        Destroy(objectToDestroy);   //peut remonter plusieurs parents 
        graphics.enabled = false;
    }
}
