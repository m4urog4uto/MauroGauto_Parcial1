using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] float _bulletSpeed;
    [SerializeField] float _bulletDamage = 5;

    EnemyBase enemyBase;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = transform.forward * _bulletSpeed;
        Destroy(gameObject, 2f);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyBase = collision.gameObject.GetComponent<EnemyBase>();
            enemyBase.TakeDamage(_bulletDamage);
        }     
    }

}
