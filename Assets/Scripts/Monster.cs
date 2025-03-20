using UnityEngine;

public class Monster : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Vérifie si l'objet en collision a le tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Affiche un message dans la console
            Debug.Log("Contact !");

            // Enregistre un indicateur dans PlayerPrefs
            PlayerPrefs.SetInt("MobDestroyed", 1);

            // Détruit l'objet Mob
            Destroy(gameObject);
        }
    }
}