using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArmamentBase : MonoBehaviour
{
    public float _bulletDamage;
    public float _bulletSpeed;

    EnemyBase enemyBase;
    PlayerBase playerBase;
    Rigidbody rb;

    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody>();

        // TODO: Agregar Delta Time
        rb.velocity = transform.forward * _bulletSpeed;
        Destroy(gameObject, 2f);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyBase = collision.gameObject.GetComponent<EnemyBase>();
            enemyBase.TakeDamage(_bulletDamage);
        }
    }

}
