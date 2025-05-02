using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Shotgun : MonoBehaviour, IWeapon
{
    [SerializeField] private Shotgun weapon;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnBullet;

    [Header("IK Shotgun Hands Target")]
    [SerializeField] private Transform IKRightHandPosShotgun;
    [SerializeField] private Transform IKLeftHandPosShotgun;

    private float timerShoot = 0;
    private float timeBetweenShoot = 1;
    private bool isPickupWeapon = false;
    void FixedUpdate()
    {
        timerShoot += Time.deltaTime;
        if (Input.GetButton("Fire1") && timerShoot > timeBetweenShoot && isPickupWeapon && spawnBullet != null && bullet != null)
        {
            Instantiate(bullet, spawnBullet.transform.position, spawnBullet.transform.rotation);
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
