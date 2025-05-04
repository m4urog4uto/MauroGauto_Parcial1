using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] protected GameObject bullet;
    [SerializeField] private float health = 100;
    [SerializeField] private int distance = 20;
    [SerializeField] int minDistanceAttack = 10;

    public int MinDistanceAttack => minDistanceAttack;

    public Animator animator;

    protected int score;

    public int Score => score;

    private GameObject player;
    private float timerShoot;
    private float timeBetweenShoot = 2;
    private bool isEnemyAlive = true;

    private float playerAndEnemyDistance;
    Dictionary<int, GameObject> pickupSupportDictionary = new Dictionary<int, GameObject>();

    protected virtual void Awake()
    {
        score = 10;
        player = GameObject.FindWithTag("Player");

        ChargePickupInDictionary(110, "PickupHealth");
        ChargePickupInDictionary(250, "PickupShield");
        ChargePickupInDictionary(300, "PickupLives");
    }
    
    protected virtual void FixedUpdate()
    {
        timerShoot += Time.deltaTime;

        if (player != null && isEnemyAlive)
        {
            playerAndEnemyDistance = Vector3.Distance(player.transform.position, transform.position);

            if (playerAndEnemyDistance < distance)
            {
                Vector3 direction = (player.transform.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f);

                if (playerAndEnemyDistance > minDistanceAttack)
                {
                    animator.SetBool("isRunning", true);
                    transform.Translate(Vector3.forward * Time.deltaTime * 3f);
                }
                else
                {
                    animator.SetBool("isRunning", false);
                }
                if (timerShoot > timeBetweenShoot)
                {
                    Shoot();
                    timerShoot = 0f;
                }
            }
        }

    }
    void ChargePickupInDictionary(int id, string key)
    {
        Addressables.LoadAssetAsync<GameObject>(key).Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                GameObject pickup = handle.Result;
                pickupSupportDictionary.Add(id, pickup);
            }
        };
    }

    public void DropPickups(int score)
    {
        if (pickupSupportDictionary.TryGetValue(score, out GameObject pickup))
        {
            Instantiate(pickup, transform.position + Vector3.up * 1f, transform.rotation);
        }
    }

    public abstract void Shoot();

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            animator.SetBool("isDeath", true);
            isEnemyAlive = false;
            Invoke("WaitAndDestroy", 3f);
        }
    }

    public void WaitAndDestroy()
    {
        Destroy(gameObject);
        GameManager.Instance.AddScore(gameObject.GetComponent<EnemyBase>().Score);
        DropPickups(GameManager.Instance.Score);
    }

    public float PlayerDistance()
    {
        return Vector3.Distance(player.transform.position, transform.position);
    }
}
