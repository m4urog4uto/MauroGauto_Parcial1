using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public int _bulletDamage = 20;
    public float _bulletSpeed;
    bool hasCollided = false;

    PlayerBase playerBase;
    Rigidbody rb;
    public void Awake()
    {
        rb = GetComponent<Rigidbody>();

        // TODO: Agregar Delta Time
        rb.velocity = transform.forward * _bulletSpeed;
        Destroy(gameObject, 2f);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (hasCollided) return;
            hasCollided = true;
            playerBase = collision.gameObject.GetComponent<PlayerBase>();
            playerBase.TakeDamage(_bulletDamage);
            Destroy(gameObject);
        }
    }

}
