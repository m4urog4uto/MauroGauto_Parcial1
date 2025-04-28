using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BulletGun : MonoBehaviour
{
    public float _bulletDamage;
    public float _bulletSpeed;

    EnemyBase enemyBase;
    ShieldEnemy shieldEnemy;
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
            GameManager.Instance.AddScore(collision.gameObject.GetComponent<EnemyBase>().Score);
        }
        else if (collision.gameObject.tag == "ShieldEnemy")
        {
            shieldEnemy = collision.gameObject.GetComponent<ShieldEnemy>();
            shieldEnemy.TakeDamage(_bulletDamage);
        }

        Destroy(gameObject);
    }

}
