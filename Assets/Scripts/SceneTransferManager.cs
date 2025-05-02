using UnityEngine;

public class SceneTransferManager : MonoBehaviour
{
    public static SceneTransferManager Instance;
    public Vector3 returnPosition;
    public bool useAlternativeSpawn = false;

    public bool isReturningFromBonus = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ne détruit pas entre les scènes
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
