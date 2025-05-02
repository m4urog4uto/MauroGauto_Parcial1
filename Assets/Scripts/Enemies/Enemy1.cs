using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemyBase, IDamageEnemy
{
    [SerializeField] private GameObject spawnBullet1;

    // [SerializeField] GameObject pickupHealth;

    // public override void DropPickups(int score)
    // {
    //     if (pickupHealth != null && score >= 10)
    //     {
    //         Instantiate(pickupHealth, transform.position, transform.rotation);
    //     }
    // }

    public override void Shoot()
    {
        Instantiate(bullet, spawnBullet1.transform.position, spawnBullet1.transform.rotation);
    }
}
