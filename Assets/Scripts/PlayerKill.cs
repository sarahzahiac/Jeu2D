using UnityEngine;
 
//SOURCE : https://www.youtube.com/watch?v=VtbHjGcsXLE
public class PlayerKill : MonoBehaviour
{
    public GameObject player;      // Assigner la porte dans l’Inspector
    public string acidTag = "Acid"; // mets "Acid" si tu préfères
    public GameObject Checkpoint; // point de respawn
 

    void OnTriggerEnter2D(Collider2D other)
    {
        //Verifie si objet est entrer dans le trigger du Player
        if (other.CompareTag("Player"))
        {
            //Teleporte le joueur au point de respawn
            player.transform.position = Checkpoint.transform.position;
        }
    }

}