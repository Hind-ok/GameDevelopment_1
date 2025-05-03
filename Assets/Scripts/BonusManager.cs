using UnityEngine;

public class BonusManager : MonoBehaviour
{
    public static BonusManager Instance;

    public int totalBonus = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // NE PAS détruire entre les scènes
        }
        else
        {
            Destroy(gameObject); // éviter les doublons
        }
    }

    public void AddBonus(int amount)
    {
        totalBonus += amount;
        Debug.Log("Bonus total: " + totalBonus);
    }

    public int GetBonus()
{
    return totalBonus;
}

}
