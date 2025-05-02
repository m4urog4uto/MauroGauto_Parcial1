using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Shield : MonoBehaviour, IDamageEnemy, IPickupSupport
{
    [SerializeField] float shieldProtection = 100f;

    [SerializeField] private Shield shield;
    Transform parent;
    ObjectPool<Shield> poolShield;

    private BoxCollider boxCollider;

    void Awake()
    {
        poolShield = new ObjectPool<Shield>(CreateItem, TakeFromPool, ReturnToPool, DestroyItem, false, 10, 100);
    }

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        parent = transform.parent;
    }

    public void TakeDamage(float damage)
    {
        shieldProtection -= damage;
        if (shieldProtection < 0)
        {
            Destroy(gameObject);
        }
    }
    public void PickupSupport(Transform spawnPoint)
    {
        Shield newSupport = poolShield.Get();
        newSupport.transform.SetParent(spawnPoint);
        newSupport.transform.localPosition = Vector3.zero;
        newSupport.transform.localRotation = Quaternion.identity;

        Destroy(gameObject);
    }

    private Shield CreateItem()
    {
        Shield newSupport = Instantiate(shield);
        newSupport.enabled = false;
        return newSupport;
    }

    private void TakeFromPool(Shield shield)
    {
        shield.enabled = true;
    }

    private void ReturnToPool(Shield shield)
    {
        shield.enabled = false;
    }

    private void DestroyItem(Shield shield)
    {
        Destroy(shield);
    }
}
