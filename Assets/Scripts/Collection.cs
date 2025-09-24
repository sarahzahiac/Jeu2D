using UnityEngine;
 
public class CollectGem : MonoBehaviour
{
 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        // TODO: incrémenter un score
 
        Destroy(gameObject); // le cristal “disparaît”
        // ou: gameObject.SetActive(false);
    }
}