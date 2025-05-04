using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RadioEnemy : MonoBehaviour, IDamageEnemy
{
    [SerializeField] float bunkerProtection = 300f;
    [SerializeField] bool isTheLast;
    [SerializeField] CounterTimerC4 counterC4;

    // Start is called before the first frame update
    public void TakeDamage(float damage)
    {
        bunkerProtection -= damage;
        if (bunkerProtection < 0)
        {
            Destroy(gameObject);
        }
    }

    public void DestroyRadioByC4()
    {
        counterC4.SetTimerActive(true);
        Destroy(gameObject, 15f);
    }
}
