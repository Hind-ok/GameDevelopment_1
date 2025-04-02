using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollusions : MonoBehaviour
{
    public int life = 3; // Points de vie du joueur
    public int choco = 0; // Points de chocolat du joueur
    private bool isDead = false; // Vérifier si le joueur est mort

    public float fallThreshold = -4f; // Seuil de chute pour redémarrer au checkpoint
    private Vector3 lastCheckpoint; // Stocke le dernier checkpoint atteint

    void Start()
    {
        lastCheckpoint = transform.position; // Au début, position de départ
    }

    private void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            Respawn(); // Ramène le joueur au dernier checkpoint au lieu de Restartlevel()
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spike"))
        {
            TakeDamages(3);
        }
        if (collision.CompareTag("Choco"))
        {
            choco += 1;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("EndLevel"))
        {
            if (PlayerPrefs.GetInt("MobDestroyed", 0) == 1)
            {
                print("Level completed");
            }
            else
            {
                print("You need to destroy the monster");
            }
        }
        if (collision.CompareTag("Checkpoint")) // Quand le joueur atteint un checkpoint
        {
            lastCheckpoint = collision.transform.position; // Sauvegarde la position du checkpoint
            Debug.Log("Checkpoint atteint : " + lastCheckpoint);
        }
    }

    public void TakeDamages(int damage)
    {
        life -= damage;
        if (life <= 0 && !isDead)
            Die();
    }

    public void Die()
    {
        isDead = true;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * 90);
        GetComponent<Collider2D>().isTrigger = true;
        Invoke("Respawn", 1); // Revient au dernier checkpoint au lieu de Restartlevel()
    }

    public void Respawn()
    {
        transform.position = lastCheckpoint; // Replace le joueur au dernier checkpoint
        GetComponent<Collider2D>().isTrigger = false; // Réactive le collider
        isDead = false;
        life = 3; // Remet les points de vie
        Debug.Log("Joueur respawn au checkpoint");
    }
}
