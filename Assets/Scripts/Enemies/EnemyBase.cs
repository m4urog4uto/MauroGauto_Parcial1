using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] protected GameObject bullet;
    [SerializeField] private float health = 100;
    [SerializeField] private int distance = 20;
    [SerializeField] int attackMovementDistance = 10;

    protected int score;

    public int Score => score;

    private GameObject player;
    private float timerShoot;
    private float timeBetweenShoot = 2;
    
    private float playerAndEnemyDistance;

    Dictionary<int, GameObject> pickupSupportDictionary = new Dictionary<int, GameObject>();

    protected virtual void Awake()
    {
        score = 10;
        player = GameObject.FindWithTag("Player");

        // ChargePickupInDictionary(10, "PickupHealth");
        ChargePickupInDictionary(10, "Shield");
        // ChargePickupInDictionary(50, "PickupLives");
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

    protected virtual void Update()
    {
        timerShoot += Time.deltaTime;

        if (player != null)
        {
            playerAndEnemyDistance = Vector3.Distance(player.transform.position, transform.position);

            if (playerAndEnemyDistance < distance)
            {
                Vector3 direction = (player.transform.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y + 5f, 0f);

                if (playerAndEnemyDistance > attackMovementDistance)
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

    }

    public void DropPickups(int score)
    {
        if (pickupSupportDictionary.TryGetValue(score, out GameObject pickup))
        {
            Instantiate(pickup, transform.position, transform.rotation);
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
            DropPickups(GameManager.Instance.Score);
        }
    }
}
