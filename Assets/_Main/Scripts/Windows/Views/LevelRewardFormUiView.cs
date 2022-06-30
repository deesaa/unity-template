using TMPro;
using UnityEngine;

public class LevelRewardFormUiView : MonoBehaviour
{
    public TMP_Text CoinsThisLevel;
    public void Open(int CoinsEarnedThisLevel)
    {
        CoinsThisLevel.text = $"+{CoinsEarnedThisLevel.ToString()}";
        gameObject.SetActive(true);
    }
}