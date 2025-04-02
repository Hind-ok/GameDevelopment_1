using UnityEngine;

public class ChocolateKey : MonoBehaviour
{
    AudioManager audioManager;  
    public void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>(); // Trouve l'AudioManager dans la scène
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>(); // Utilise "Player" au lieu de "PlayerController"
            if (player != null)
            {
                player.JumpOfJoy(); // Méthode pour faire sauter le joueur
            }
            if (audioManager != null)
                {
                  audioManager.PlaySFX(audioManager.KetFinish); // Joue le son de fin de niveau    
                }
                else
                {
                    Debug.LogWarning("AudioManager non trouvé !");
                }
            Destroy(gameObject); // Détruit la clé après collecte
        }
    }
}


    

