using UnityEngine;
public class EnemyFinal : EnemyBase, IDamageEnemy
{
    [SerializeField] protected GameObject GranadeEnemy;

    [SerializeField] private GameObject spawnGranade1;
    [SerializeField] private GameObject spawnGranade2;
    [SerializeField] private GameObject spawnBullet1;

    protected override void Awake()
    {
        base.Awake();
        score = 100;
    }

    public override void Shoot()
    {
        Instantiate(GranadeEnemy, spawnGranade1.transform.position, spawnGranade1.transform.rotation);
        Instantiate(GranadeEnemy, spawnGranade2.transform.position, spawnGranade2.transform.rotation);
        Instantiate(bullet, spawnBullet1.transform.position, spawnBullet1.transform.rotation);
    }
}
