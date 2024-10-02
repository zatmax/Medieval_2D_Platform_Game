using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour
{ 
    public SpriteRenderer spriteRenderer;
    private Animator fadeSystem;
    public int damage;
    public AudioClip soundToPlay;

    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(soundToPlay, transform.position);
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
            fadeSystem.SetTrigger("FadeIn");
            StartCoroutine(ReplacePlayer(collision));
            spriteRenderer.flipX = false;
        }
    }

    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        yield return new WaitForSeconds(1f);
        collision.transform.position = CurrentSceneManager.instance.respawnPoint;
    }
}
