using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RadioSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> radioEnemies = new List<GameObject>();
    // Start is called before the first frame update
    [SerializeField] private string nextScene;
    void Start()
    {
    }

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
            SceneManager.LoadScene("Credits");
        }
    }
}
