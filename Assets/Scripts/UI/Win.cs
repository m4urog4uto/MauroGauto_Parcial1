using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
     public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitScene()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else        
        Application.Quit();
        #endif
    }
}
