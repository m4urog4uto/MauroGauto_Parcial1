using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemy : MonoBehaviour, IDamageEnemy
{
    [SerializeField] float shield = 100f;
    // Start is called before the first frame update
    public void TakeDamage(float damage)
    {
        shield -= damage;
        if (shield < 0)
        {
            Destroy(gameObject);
        }
    }
}
