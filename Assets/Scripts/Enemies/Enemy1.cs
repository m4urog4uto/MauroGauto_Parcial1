using UnityEngine;

public class Enemy1 : EnemyBase, IDamageEnemy
{
    [SerializeField] private GameObject spawnBullet1;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public override void Shoot()
    {
        if (spawnBullet1 != null)
        {
            audioSource.Play();
            Instantiate(bullet, spawnBullet1.transform.position, spawnBullet1.transform.rotation);
        }
    }
}
