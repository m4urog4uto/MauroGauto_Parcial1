using UnityEngine;

public class Enemy1 : EnemyBase, IDamageEnemy
{
    [SerializeField] private GameObject spawnBullet1;
    public override void Shoot()
    {
        Instantiate(bullet, spawnBullet1.transform.position, spawnBullet1.transform.rotation);
    }
}
