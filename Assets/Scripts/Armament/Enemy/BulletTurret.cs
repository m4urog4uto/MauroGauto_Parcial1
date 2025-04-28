using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTurret : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 10f;
    Rigidbody rb;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();

        // TODO: Agregar Delta Time
        rb.velocity = transform.forward * _bulletSpeed;
        Destroy(gameObject, 2f);
    }
    void OnCollisionEnter(Collision collision) {
        // if (collision.gameObject.tag == "Player")
        // {
            // playerBase = collision.gameObject.GetComponent<PlayerBase>();
            // playerBase.TakeDamage(_bulletDamage);
        // }     
    }
}