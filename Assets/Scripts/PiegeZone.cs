using UnityEngine;
using System.Collections;

public class PiegeZone : MonoBehaviour
{
    public int damage;
    public AudioClip soundToPlay;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(soundToPlay, transform.position);
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
            
        }
    }

 
}
