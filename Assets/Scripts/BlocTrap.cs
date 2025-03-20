using UnityEngine;

public class BlocTap : MonoBehaviour
{
        public GameObject connectedBloc;
        public Collider2D colliderToActivate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject.GetComponent<SpriteRenderer>()); // Destroy the object 
    }
   private void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifie si l'objet en collision a le tag "Player"
        if (collision.CompareTag("Player"))
        {
            // Ajoute un composant Rigidbody2D à l'objet connectedBloc
            connectedBloc.AddComponent<Rigidbody2D>();
            colliderToActivate.enabled = true;
            Destroy(gameObject); // Détruit l'objet en collision
        }
    }
}
