using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RadioSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> radioEnemies = new List<GameObject>();
    [SerializeField] private string nextScene;

    [SerializeField] Fade fadeAnimator;

    private int totalRadioEnemies;
    private int currentRadiosDestroyed = 0;

    public int TotalRadiosEnemies => totalRadioEnemies;

    void Start()
    {
        totalRadioEnemies = radioEnemies.Count;
    }

    void Update()
    {
        if (radioEnemies.Count != 0)
        {
            for (int i = 0; i < radioEnemies.Count; i++)
            {
                if (radioEnemies[i] == null)
                {
                    currentRadiosDestroyed += 1;
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

    public int CurrentRadiosDestroyed => currentRadiosDestroyed;

    public int TotalRadios(int totalRadios)
    {
        return totalRadios;
    }

    void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
