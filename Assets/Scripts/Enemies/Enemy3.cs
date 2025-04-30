using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : EnemyBase, IDamageEnemy
{
    [SerializeField] private GameObject granadeSpawn;

    protected override void Awake()
    {
        base.Awake();
        score = 30;
    }

    public override void Shoot()
    {
        Instantiate(bullet, granadeSpawn.transform.position, granadeSpawn.transform.rotation);
    }
}
