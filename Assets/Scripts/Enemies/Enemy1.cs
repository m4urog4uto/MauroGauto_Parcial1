using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemyBase
{
    [SerializeField] float m_health = 100f;

    [SerializeField] private GameObject spawnBullet1;

    public override void Shoot()
    {
        Instantiate(bullet, spawnBullet1.transform.position, spawnBullet1.transform.rotation);
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
