using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterTimerC4 : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    AudioSource audioSource;
    public float countdownTime = 15f;
    private bool isTimerActive = false;

    public void SetTimerActive(bool value)
    {
        isTimerActive = value;
        if (isTimerActive)
        {
            audioSource.Play();
        }
    }

    public bool GetTimerActive()
    {
        return isTimerActive;
    }

    private float currentTime;

    void Start()
    {
        currentTime = countdownTime;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isTimerActive)
        {
            currentTime -= Time.deltaTime;
            currentTime = Mathf.Max(currentTime, 0f);
            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        timerText.text = currentTime.ToString("F1");
        if (currentTime == 0)
        {
            audioSource.Stop();
            currentTime = 15f;
            timerText.text = "";
            isTimerActive = false;
        }
    }
}
