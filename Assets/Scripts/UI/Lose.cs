using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Lose : MonoBehaviour
{
    [SerializeField] UIDocument uiDocument;

    void OnEnable()
    {
        var root = uiDocument.rootVisualElement;

        Button playerButton = root.Q<Button>("button-restart");

        playerButton.clicked += () => ChangeScene("Level1");
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
