using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Shotgun : MonoBehaviour, IWeapon
{
    [SerializeField] private Shotgun weapon;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnBullet;
    Transform parent;

    ObjectPool<Shotgun> poolShotgun;

    private float timerShoot = 0;
    private float timeBetweenShoot = 1;

    void Awake()
    {
        poolShotgun = new ObjectPool<Shotgun>(CreateItem, TakeFromPool, ReturnToPool, DestroyItem, false, 10, 100);
    }

    void Start()
    {
        parent = transform.parent;
    }

    void FixedUpdate()
    {
        timerShoot += Time.deltaTime;

        if (Input.GetButton("Fire1") && timerShoot > timeBetweenShoot && parent != null && spawnBullet != null && bullet != null)
        {
            Instantiate(bullet, spawnBullet.transform.position, spawnBullet.transform.rotation);
            timerShoot = 0f;
        }
    }
    public void PickupWeapon(Transform spawnWeapon)
    {
        Shotgun newWeapon = poolShotgun.Get();
        newWeapon.transform.SetParent(spawnWeapon);
        newWeapon.transform.localPosition = Vector3.zero;
        newWeapon.transform.localRotation = Quaternion.identity;

        Destroy(gameObject);
    }

    
    private Shotgun CreateItem()
    {
        Shotgun newWeapon = Instantiate(weapon);
        newWeapon.enabled = false;
        return newWeapon;
    }

    private void TakeFromPool(Shotgun weapon)
    {
        weapon.enabled = true;
    }

    private void ReturnToPool(Shotgun weapon)
    {
        weapon.enabled = false;
    }

    private void DestroyItem(Shotgun weapon)
    {
        Destroy(weapon);
    }
}
