using TMPro;
using UnityEngine;

public class LivesText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI livesText;

    [SerializeField] PlayerBase playerBase;

    void Update()
    {
        livesText.text = $"x{GameManager.Instance.Lives}";
    }
}
