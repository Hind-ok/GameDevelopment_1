using System.Collections;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
       
    }


    
    //methode pour faire disparaitre le fantome
     private void OnCollisionEnter2D(Collision2D collision)
    {
        // Vérifie si l'objet en collision a le tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Affiche un message dans la console
            Debug.Log("Contact !");

            // Enregistre un indicateur dans PlayerPrefs
            PlayerPrefs.SetInt("GhostDestroyed", 1);

            // Détruit l'objet Mob
            Destroy(gameObject);
        }
    }
}
