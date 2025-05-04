using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    List<IObserver> observers = new List<IObserver>();

    public static GameManager Instance => instance;

    private int score;
    private int lives = 3;

    public int Lives => lives;

    public int Score => score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        NotifyObservers();
    }

    public void RemoveLives()
    {
        lives -= 1;
    }

    public void AddLives()
    {
        lives += 1;
    }

    public void AddObserver(IObserver observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    public void RemoveObserver(IObserver observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }

    private void NotifyObservers()
    {
        for (int i = 0; i < observers.Count; i++)
        {
            observers[i].OnNotify(score);
        }
    }
}
