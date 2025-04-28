using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;

    [SerializeField] PlayerBase playerBase;

    void Update()
    {
        if (playerBase != null)
        {
            healthText.text = $"Salud: {playerBase.GetHealth()}%";
        }
    }
}
