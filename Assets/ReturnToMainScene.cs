using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainScene : MonoBehaviour
{
    public string mainSceneName = "Level 2";

    private void OnTriggerEnter2D(Collider2D collision)
    {
if (collision.CompareTag("Player"))
{
    SceneTransferManager.Instance.useAlternativeSpawn = true;
    SceneManager.sceneLoaded += OnMainSceneLoaded;
    SceneManager.LoadScene(mainSceneName);
}

    }

   void OnMainSceneLoaded(Scene scene, LoadSceneMode mode)
{
    GameObject player = GameObject.FindGameObjectWithTag("Player");

    if (player != null)
    {
        if (SceneTransferManager.Instance.useAlternativeSpawn)
        {
            GameObject spawnPoint = GameObject.Find("ReturnPosition"); // nom exact du point
            if (spawnPoint != null)
            {
                player.transform.position = spawnPoint.transform.position;
            }
        }
        else
        {
            player.transform.position = SceneTransferManager.Instance.returnPosition;
        }
    }

    SceneTransferManager.Instance.useAlternativeSpawn = false; // reset
    SceneManager.sceneLoaded -= OnMainSceneLoaded;
}

}
