using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pistol : MonoBehaviour, IWeapon
{
    [SerializeField] private Pistol weapon;
    [SerializeField] private GameObject bulletPistol;
    [SerializeField] private Transform spawnBullet;

    [Header("IK Shotgun Hands Target")]
    [SerializeField] private Transform IKRightHandPosShotgun;
    [SerializeField] private Transform IKLeftHandPosShotgun;

    private bool isPickupWeapon = false;

    private float timerShoot = 0;
    private float timeBetweenShoot = 1;
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

    public void PickupWeapon(Transform aimingShotgunSpawn, Transform leftHandTarget, Transform rightHandTarget)
    {
        transform.SetParent(aimingShotgunSpawn.transform);
        transform.position = aimingShotgunSpawn.position;
        transform.rotation = aimingShotgunSpawn.rotation;

        leftHandTarget.position = IKLeftHandPosShotgun.position;
        leftHandTarget.rotation = IKLeftHandPosShotgun.rotation;

        rightHandTarget.position = IKRightHandPosShotgun.position;
        rightHandTarget.rotation = IKRightHandPosShotgun.rotation;

        isAiming(true);
    }
}
