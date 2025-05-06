using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioExplosionSound : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    AudioClip audioClip;
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource = audioSource.GetComponent<AudioSource>();
        audioClip = Resources.Load<AudioClip>("Enemies/RadioExplosion");
        audioSource.enabled = true;
        audioSource.gameObject.SetActive(true);
        audioSource.clip = audioClip;
    }

    public void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
            Destroy(gameObject, 1f);
        }
    }
}
