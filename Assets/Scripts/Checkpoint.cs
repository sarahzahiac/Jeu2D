using UnityEngine;

//SOURCE : https://www.youtube.com/watch?v=VtbHjGcsXLE
//Ce script gere le systeme de checkpoint
//Lorsqun joueur entre en contact aveec le piege il respwan cci
public class Checkpoint : MonoBehaviour
{
    private PlayerKill respawn;

    void Awake()
    {
        //Recherche de tag "Acid" et sa contient a gestion du contact avec l'acide
        respawn = GameObject.FindGameObjectWithTag("Acid").GetComponent<PlayerKill>();
  
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Lorsque objet entre en contact avec la zon du checkpoint
        if (other.CompareTag("Player"))
        {
            //Definit ce checkpoint comme nouveau point de reaparition
            respawn.Checkpoint = this.gameObject;
        
        }
    }

}