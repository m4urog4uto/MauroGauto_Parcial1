using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pistol : MonoBehaviour, IWeapon
{
    [SerializeField] private Pistol weapon;
    [SerializeField] private GameObject bulletPistol;
    [SerializeField] private Transform spawnBullet;
    [SerializeField] private Transform aimingPistolSpawn;
     [SerializeField] private Transform weaponPositions;

    [Header("IK Shotgun Hands Target")]
    [SerializeField] private Transform IKRightHandPosShotgun;
    [SerializeField] private Transform IKLeftHandPosShotgun;

    private bool isPickupWeapon = false;

    private float timerShoot = 0;
    private float timeBetweenShoot = 1;
    void FixedUpdate()
    {
        timerShoot += Time.deltaTime;

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

    public void PickupWeapon(Transform leftHandTarget, Transform rightHandTarget)
    {
        Transform spawnShotgun = weaponPositions.GetChild(0);
        if (spawnShotgun.childCount > 0)
        {
            Transform weapon = spawnShotgun.GetChild(0);
            Destroy(weapon.gameObject);
        }

        transform.SetParent(aimingPistolSpawn.transform);
        transform.position = aimingPistolSpawn.position;
        transform.rotation = aimingPistolSpawn.rotation;

        leftHandTarget.position = IKLeftHandPosShotgun.position;
        leftHandTarget.rotation = IKLeftHandPosShotgun.rotation;

        rightHandTarget.position = IKRightHandPosShotgun.position;
        rightHandTarget.rotation = IKRightHandPosShotgun.rotation;

        isAiming(true);
    }
}
