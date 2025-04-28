using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] private int distance = 20;
    [SerializeField] protected GameObject bullet;

    protected int score;

    public int Score => score;

    private GameObject player;
    private float timerShoot;
    private float timeBetweenShoot = 2;

    protected virtual void Awake()
    {
        score = 1;
        player = GameObject.FindWithTag("Player");
    }

    protected virtual void Update()
    {
        timerShoot += Time.deltaTime;

        if (Vector3.Distance(player.transform.position, transform.position) < distance)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y + 5f, 0f);
            if (timerShoot > timeBetweenShoot)
            {
                Shoot();
                timerShoot = 0f;
            }
        }
    }

    public abstract void Shoot();

    public abstract void TakeDamage(float damage);
}
