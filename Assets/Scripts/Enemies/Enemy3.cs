using UnityEngine;

public class Enemy3 : EnemyBase, IDamageEnemy
{
    [SerializeField] private GameObject granadeSpawn;
    [SerializeField] private GameObject granade;
    [SerializeField] AudioSource audioSource;

    public override void Shoot()
    {
        if (PlayerDistance() <= MinDistanceAttack)
        {
            audioSource.Play();
            Instantiate(granade, granadeSpawn.transform.position, granadeSpawn.transform.rotation);
        }
    }
}
