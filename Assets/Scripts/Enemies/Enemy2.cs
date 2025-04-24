using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnemyBase
{
    [SerializeField] float m_health = 130f;

    [SerializeField] private GameObject spawnBullet1;
    [SerializeField] private GameObject spawnBullet2;

    public override void Shoot()
    {
        Instantiate(bullet, spawnBullet1.transform.position, spawnBullet1.transform.rotation);
        Instantiate(bullet, spawnBullet2.transform.position, spawnBullet2.transform.rotation);
    }

    public override void TakeDamage(float damage)
    {
        m_health -= damage;
        if (m_health < 0)
        {
            Destroy(gameObject);
        }
    }
}
