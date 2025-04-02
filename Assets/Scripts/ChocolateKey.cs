using UnityEngine;

public class ChocolateKey : MonoBehaviour
{
    private AudioManager audioManager;  

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>(); // Trouve l'AudioManager dans la scène
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>(); 
            if (player != null)
            {
                player.JumpOfJoy(); // Fait sauter le joueur de joie
            }

            if (audioManager != null)
            {
                audioManager.PlaySFX(audioManager.KetFinish); // Joue le son de fin de niveau
                Invoke("GoToNextLevel", 1f); // Attend 5 secondes avant de changer de niveau
            }
            else
            {
                Debug.LogWarning("AudioManager non trouvé !");
            }

            // Désactiver l'objet au lieu de le détruire immédiatement
            gameObject.SetActive(false);
        }
    }

    private void GoToNextLevel()
    {
        SceneController.instance.NextLevel(); // Passe au niveau suivant
        Destroy(gameObject); // Détruire l'objet après le changement de niveau
    }
}
