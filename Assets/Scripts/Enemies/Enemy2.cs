using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnemyBase, IDamageEnemy
{
    [SerializeField] private GameObject spawnBullet1;
    [SerializeField] private GameObject spawnBullet2;

    protected override void Awake()
    {
        base.Awake();
        score = 20;
    }

    public override void Shoot()
    {
        Instantiate(bullet, spawnBullet1.transform.position, spawnBullet1.transform.rotation);
        Instantiate(bullet, spawnBullet2.transform.position, spawnBullet2.transform.rotation);
    }
}
