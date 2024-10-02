using UnityEngine;
using System.Collections;

public class BarrelWeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;
    public Animator animator;
    public CircleCollider2D BarrelCollider;
    public AudioClip destroySound;
    public SpriteRenderer graphics;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //attention risque pb ici, allocation box collider dans inspector impossible à déposer, fait par recherche
            BarrelCollider.enabled = false;
            AudioManager.instance.PlayClipAt(destroySound, transform.position);
            StartCoroutine(DeathDelay());
            //revenir sur erreur instance ici plus tard
        }
    }

    public IEnumerator DeathDelay()
    {
        animator.SetTrigger("Explosion");
        Inventory.instance.AddCoins(2);
        yield return new WaitForSeconds(0.8f);
        Destroy(objectToDestroy);   //peut remonter plusieurs parents
        graphics.enabled = false;
    }
}
