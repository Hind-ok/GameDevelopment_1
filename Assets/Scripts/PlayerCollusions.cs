using UnityEngine;
using UnityEngine.SceneManagement; // Importe le module SceneManager
public class PlayerCollusions : MonoBehaviour
{
public int life = 3; // Points de vie du joueur
public int choco = 0; // Points de chocolat du joueur
bool isDead = false; // Variable pour savoir si le joueur est mort

public float fallThreshold = -4f; // Seuil de chute pour redémarrer le niveau

    // Méthode appelée à chaque frame
    private void Update()
    {
        // Vérifie si le joueur est tombé en dessous du seuil
        if (transform.position.y < fallThreshold)
        {
            Restartlevel(); // Redémarre le niveau
        }
    }

    // Méthode appelée lorsque le joueur entre en collision avec un autre objet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifie si l'objet en collision a le tag "Spike"
        if (collision.CompareTag("Spike"))
        {
            TakeDamages(3); // Applique des dégâts au joueur
        }
        if (collision.CompareTag("Choco"))
        {
            choco += 1; // Ajoute un point de chocolat au joueur
            Destroy(collision.gameObject); // Détruit l'objet en collision
        }
        if (collision.CompareTag("EndLevel"))
        {
            if (PlayerPrefs.GetInt("MobDestroyed",0) == 1)
            {
              print("Level completed");
            }
            else{
              print("You need to destroy the monster");
            }
        }
    }

    // Méthode pour appliquer des dégâts au joueur
    public void TakeDamages(int damage)
    {
        life -= damage; // Réduit les points de vie du joueur

        // Vérifie si le joueur n'a plus de vie
        if (life <= 0 && !isDead)
            Die(); // Appelle la méthode pour gérer la mort du joueur
    }

    // Méthode pour gérer la mort du joueur
    public void Die()
    {
        isDead = true; // Indique que le joueur est mort
        GetComponent<Rigidbody2D>().linearVelocity=Vector2.zero; 
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * 90); // Désactive la physique du joueur
        GetComponent<Collider2D>().isTrigger = true; // Désactive le collider du joueur
        Invoke("Restartlevel", 1); // Relance la scène après 1 seconde
    }
    public void Restartlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Relance la scène actuelle
    }
}
