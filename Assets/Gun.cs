using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Gun : MonoBehaviour, IWeapon
{
    [SerializeField] private Gun weapon;
    [SerializeField] private GameObject bulletGun;
    [SerializeField] private Transform spawnBullet;
    Transform parent;
    ObjectPool<Gun> poolGun;

    float timerShoot = 0;
    float timeBetween = 1;

    void Awake()
    {
        poolGun = new ObjectPool<Gun>(CreateItem, TakeFromPool, ReturnToPool, DestroyItem, false, 10, 100);
    }

    void Start()
    {
        
        parent = transform.parent;
    }

    void FixedUpdate()
    {
        timerShoot += Time.deltaTime;

        if (Input.GetButton("Fire1") && timerShoot > timeBetween && parent != null && spawnBullet != null && bulletGun != null)
        {
            Instantiate(bulletGun, spawnBullet.transform.position, spawnBullet.transform.rotation);
        }
    }

    public void PickupWeapon(Transform spawnWeapon)
    {
        Gun newWeapon = poolGun.Get();
        newWeapon.transform.SetParent(spawnWeapon);
        newWeapon.transform.localPosition = Vector3.zero;
        newWeapon.transform.localRotation = Quaternion.identity;

        Destroy(gameObject);
    }

    private Gun CreateItem()
    {
        Gun newWeapon = Instantiate(weapon);
        newWeapon.enabled = false;
        return newWeapon;
    }

    private void TakeFromPool(Gun weapon)
    {
        weapon.enabled = true;
    }

    private void ReturnToPool(Gun weapon)
    {
        weapon.enabled = false;
    }

    private void DestroyItem(Gun weapon)
    {
        Destroy(weapon);
    }
}
