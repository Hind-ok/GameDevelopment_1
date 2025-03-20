using UnityEngine;

public class ChocolateKey : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>(); // Utilise "Player" au lieu de "PlayerController"
            if (player != null)
            {
                player.JumpOfJoy(); // Méthode pour faire sauter le joueur
            }

            Destroy(gameObject); // Détruit la clé après collecte
        }
    }
}


    

