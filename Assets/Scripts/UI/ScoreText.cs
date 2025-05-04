using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour, IObserver
{
    [SerializeField] private TextMeshProUGUI scoreText;
    public void OnNotify(int score)
    {
        scoreText.text = $"Score: {score.ToString()}";
    }

    private void Start()
    {
        GameManager.Instance.AddObserver(this);
    }
}
