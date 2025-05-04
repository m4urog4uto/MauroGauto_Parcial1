using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RadioSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> radioEnemies = new List<GameObject>();
    [SerializeField] private string nextScene;

    [SerializeField] Fade fadeAnimator;

    void Update()
    {
        if (radioEnemies.Count != 0)
        {
            for (int i = 0; i < radioEnemies.Count; i++)
            {
                if (radioEnemies[0] == null)
                {
                    radioEnemies.RemoveAt(i);
                }
            }
        }
        else
        {
            fadeAnimator.FadeOut();
            Invoke("NextScene", 2f);
        }
    }

    void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
