using TMPro;
using UnityEngine;

public class LivesText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI livesText;

    [SerializeField] PlayerBase playerBase;

    void Update()
    {
        if (playerBase != null)
        {
            livesText.text = $"Vidas: {playerBase.GetLives()}";
        }
    }
}
