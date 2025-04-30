using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] private int distance = 20;
    [SerializeField] private int attackDistance = 10;
    [SerializeField] protected GameObject bullet;

    [SerializeField] private float health = 100;

    protected int score;

    public int Score => score;

    private GameObject player;
    private float timerShoot;
    private float timeBetweenShoot = 2;
    
    private float playerAndEnemyDistance;

    protected virtual void Awake()
    {
        score = 10;
        player = GameObject.FindWithTag("Player");
    }

    protected virtual void Update()
    {
        timerShoot += Time.deltaTime;
        playerAndEnemyDistance = Vector3.Distance(player.transform.position, transform.position);

        if (player != null && playerAndEnemyDistance < distance)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y + 5f, 0f);
            if (playerAndEnemyDistance > attackDistance)
            {
                transform.Translate(Vector3.forward * Time.deltaTime);
            }
            if (timerShoot > timeBetweenShoot)
            {
                Shoot();
                timerShoot = 0f;
            }
        }
    }

    public abstract void Shoot();

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            Destroy(gameObject);
            GameManager.Instance.AddScore(gameObject.GetComponent<EnemyBase>().Score);
        }
    }
}
