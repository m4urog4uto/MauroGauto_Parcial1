using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    List<IObserver> observers = new List<IObserver>();

    public static GameManager Instance => instance;

    private int score;

    public int Score => score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        NotifyObservers();
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
