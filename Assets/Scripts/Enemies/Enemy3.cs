using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : EnemyBase
{
    [SerializeField] float health = 200f;

    [SerializeField] private GameObject granadeSpawn;

    protected override void Awake()
    {
        base.Awake();
        score = 20;
    }

    public override void Shoot()
    {
        Instantiate(bullet, granadeSpawn.transform.position, granadeSpawn.transform.rotation);
    }

    public override void TakeDamage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
}
