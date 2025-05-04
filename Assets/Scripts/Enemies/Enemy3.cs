using UnityEngine;

public class Enemy3 : EnemyBase, IDamageEnemy
{
    [SerializeField] private GameObject granadeSpawn;
    [SerializeField] private GameObject granade;

    public override void Shoot()
    {
        if (PlayerDistance() <= MinDistanceAttack)
        {
            Instantiate(granade, granadeSpawn.transform.position, granadeSpawn.transform.rotation);
        }
    }
}
