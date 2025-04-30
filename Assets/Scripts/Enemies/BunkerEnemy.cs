using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BunkerEnemy : MonoBehaviour, IDamageEnemy
{
    [SerializeField] float bunkerProtection = 300f;
    // Start is called before the first frame update
    public void TakeDamage(float damage)
    {
        bunkerProtection -= damage;
        if (bunkerProtection < 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Win");
        }
    }
}
