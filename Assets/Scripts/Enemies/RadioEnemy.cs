using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RadioEnemy : MonoBehaviour, IDamageEnemy
{
    [SerializeField] float bunkerProtection = 300f;
    [SerializeField] bool isTheLast;
    // Start is called before the first frame update
    public void TakeDamage(float damage)
    {
        bunkerProtection -= damage;
        if (bunkerProtection < 0)
        {
            Destroy(gameObject);
            if (isTheLast)
            {
                SceneManager.LoadScene("Win");
            }
        }
    }
}
