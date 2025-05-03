using TMPro;
using UnityEngine;

public class BonusUI : MonoBehaviour
{
    public TextMeshProUGUI bonusText;
    public TextMeshProUGUI bonusText2;
    public TextMeshProUGUI bonusText3;


    void Update()
    {
        bonusText.text = BonusManager.Instance.GetBonus().ToString();
        bonusText2.text = BonusManager.Instance.GetBonus().ToString();
        bonusText3.text = BonusManager.Instance.GetBonus().ToString();
    }
}
