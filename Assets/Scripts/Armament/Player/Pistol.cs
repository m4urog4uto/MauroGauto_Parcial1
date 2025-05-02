using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pistol : MonoBehaviour, IWeapon
{
    [SerializeField] private Pistol weapon;
    [SerializeField] private GameObject bulletPistol;
    [SerializeField] private Transform spawnBullet;
    Transform parent;
    ObjectPool<Pistol> poolPistol;
    private bool isPickupWeapon = false;

    private float timerShoot = 0;
    private float timeBetweenShoot = 1;

    void Awake()
    {
        poolPistol = new ObjectPool<Pistol>(CreateItem, TakeFromPool, ReturnToPool, DestroyItem, false, 10, 100);
    }

    void Start()
    {
        
        parent = transform.parent;
    }

    void FixedUpdate()
    {
        timerShoot += Time.deltaTime;

        //  && timerShoot > timeBetween CON ESTA CONDICION NO ESTARIA DISPARANDO

        if (Input.GetButton("Fire1") && timerShoot > timeBetweenShoot && isPickupWeapon && spawnBullet != null && bulletPistol != null)
        {
            Instantiate(bulletPistol, spawnBullet.transform.position, spawnBullet.transform.rotation);
            timerShoot = 0f;
        }
    }

    public void isAiming(bool value)
    {
        isPickupWeapon = value;
    }

    public void PickupWeapon(Transform spawnWeapon)
    {
        Pistol newWeapon = poolPistol.Get();
        // newWeapon.transform.SetParent(spawnWeapon);
        // newWeapon.transform.localPosition = Vector3.zero;
        // newWeapon.transform.localRotation = Quaternion.identity;

        transform.parent = spawnWeapon.transform;

        transform.position = spawnWeapon.position;
        transform.rotation = spawnWeapon.rotation;
    }

    private Pistol CreateItem()
    {
        Pistol newWeapon = Instantiate(weapon);
        newWeapon.enabled = false;
        return newWeapon;
    }

    private void TakeFromPool(Pistol weapon)
    {
        weapon.enabled = true;
    }

    private void ReturnToPool(Pistol weapon)
    {
        weapon.enabled = false;
    }

    private void DestroyItem(Pistol weapon)
    {
        Destroy(weapon);
    }
}
