using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToBonus : MonoBehaviour
{
    public string bonusSceneName = "Level 3"; // nom exact de ta scène bonus

   private bool canTeleport = true;

private void OnTriggerEnter2D(Collider2D collision)
{
    if (!canTeleport || SceneTransferManager.Instance.isReturningFromBonus) return;

    if (collision.CompareTag("Player"))
    {
        SceneTransferManager.Instance.returnPosition = collision.transform.position;
        SceneManager.LoadScene(bonusSceneName);
    }
}

}
