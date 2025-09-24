using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Pour les Coroutines
public class PlayerHealth : MonoBehaviour
{
    // Nombre de points de vie maximum du joueur (réglable dans l’Inspector).
    public int maxHealth = 5;
   
    // Points de vie courants (privé pour éviter des modifications externes accidentelles).
    private int currentHealth;
    private Animator animator;
    private float reloadDelay = 1f;
    public string sceneToLoad = "GameOver";
 
    // Awake est appelé au chargement du GameObject (avant Start).
    // On initialise les PV courants au maximum.
    void Awake() => currentHealth = maxHealth;
 
    // Méthode à appeler quand le joueur subit des dégâts.
    // 'dmg' représente la quantité de dégâts à retirer.
    public void TakeDamage(int dmg)
    {
        // On soustrait les PV.
        currentHealth -= dmg;
 
        // Log de debug pour visualiser la perte de PV dans la Console.
        Debug.Log("Player prend " + dmg + " dégâts. HP restants = " + currentHealth);
 
        // Si les PV tombent à 0 ou moins, on déclenche la mort.
        if (currentHealth <= 0) Die();
           currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
 
    // Gère la mort du joueur : animations, désactivation d’input, rechargement de scène, etc.
    void Die()
    {
        Debug.Log("Player est mort !");
 
        animator = GetComponent<Animator>();
        GetComponent<PlayerMove>().enabled = false;
        animator.SetTrigger("Dead");
        if (reloadDelay <= 0f) SceneManager.LoadScene(sceneToLoad);
        else StartCoroutine(WaitAndReloadScene(sceneToLoad));
       
       
    }
 
    // Coroutine pour attendre avant de recharger la scène
    IEnumerator WaitAndReloadScene(string name)
    {
        // Attente de reloadDelay secondes avant de recharger la scène
        yield return new WaitForSeconds(reloadDelay);
 
        // Rechargement de la scène actuelle
        SceneManager.LoadScene(name);
    }
}
 