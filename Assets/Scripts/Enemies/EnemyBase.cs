using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] float m_health = 100f;
    [SerializeField] private int distance = 10;
    [SerializeField] protected GameObject bullet;
    [SerializeField] private GameObject spawnBullet;

    private GameObject player;
    private float timerShoot;
    private float timeBetweenShoot = 2;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    protected virtual void Update()
    {
        timerShoot += Time.deltaTime;

        if (Vector3.Distance(player.transform.position, transform.position) < distance)
        {
            if (timerShoot > timeBetweenShoot)
            {
                Shoot();
                timerShoot = 0f;
            }
        }
    }

    void Shoot()
    {
        Instantiate(bullet, spawnBullet.transform.position, spawnBullet.transform.rotation);
    }

    public void GetDamage(float damage)
    {
        m_health -= damage;
        if (m_health < 0)
        {
            Destroy(gameObject);
        }
    }
}
