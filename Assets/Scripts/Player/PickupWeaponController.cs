using UnityEngine.Animations.Rigging;
using UnityEngine;
using System;

public class PickupWeaponController : PlayerBase
{
    [Header("Ray Settings")]

    [SerializeField][Range(0.06f, 0.5f)] private float rayLength;
    [SerializeField] private Vector3 rayOffset;
    [SerializeField] private LayerMask weaponMask;
    private RaycastHit topRayHitInfo;

    private Pistol pistol;
    private Shotgun shotgun;

    [Header("Aiming Weapons")]
    [SerializeField] private Transform aimingShotgunSpawn;
    [SerializeField] private Transform aimingPistolSpawn;

    [Header("Right Hand Target")]
    [SerializeField] private TwoBoneIKConstraint rightHandIK;
    [SerializeField] private Transform rightHandTarget;

    [Header("Left Hand Target")]
    [SerializeField] private TwoBoneIKConstraint leftHandIK;
    [SerializeField] private Transform leftHandTarget;


    void Update()
    {
        leftHandIK.weight = 0f;
        if (shotgun != null)
        {
            DestroyPreviousWeapon(aimingPistolSpawn);

            shotgun.PickupWeapon(aimingShotgunSpawn, leftHandTarget, rightHandTarget);

            ActivateAnimations();
        }
        else if (pistol != null)
        {
            DestroyPreviousWeapon(aimingShotgunSpawn);

            pistol.PickupWeapon(aimingPistolSpawn, leftHandTarget, rightHandTarget);
            
            ActivateAnimations();
        }
    }

    void DestroyPreviousWeapon(Transform weaponSpawn)
    {
        if (weaponSpawn != null && weaponSpawn.childCount > 0)
        {
            Destroy(weaponSpawn.GetChild(0).gameObject);
        }
    }

    void ActivateAnimations()
    {
        leftHandIK.weight = 1f;
        rightHandIK.weight = 1f;

        SetAnimationIsArmed(true);
    }

    void FixedUpdate()
    {
        RaycastHandler();
    }

    private void RaycastHandler()
    {
        Ray topRay = new Ray(transform.position + rayOffset, transform.forward);
        Debug.DrawRay(transform.position + rayOffset, transform.forward * rayLength, Color.red);
        Physics.Raycast(topRay, out topRayHitInfo, rayLength, weaponMask);

        PickupWeapon();
    }

    private void PickupWeapon()
    {
        if (topRayHitInfo.collider != null)
        {
            shotgun = topRayHitInfo.transform.gameObject.GetComponent<Shotgun>();
            pistol = topRayHitInfo.transform.gameObject.GetComponent<Pistol>();
            // IWeapon weapon = other.GetComponent<IWeapon>();
            // if (weapon != null)
            // {
            //     if (weaponSpawn != null && weaponSpawn.childCount > 2)
            //     {
            //         Destroy(weaponSpawn.GetChild(2).gameObject);
            //     }
            //     weapon.PickupWeapon(weaponSpawn);

            // }
        }
    }
}









// public class PickupWeaponController : PlayerBase
// {
//     [SerializeField] private Transform weaponSpawn;

//     private void OnTriggerEnter(Collider other)
//     {

//         IWeapon weapon = other.GetComponent<IWeapon>();
//         if (weapon != null)
//         {
//             if (weaponSpawn != null && weaponSpawn.childCount > 2)
//             {
//                 Destroy(weaponSpawn.GetChild(2).gameObject);
//             }
//             weapon.PickupWeapon(weaponSpawn);

//         }
//         SetIsArmed(true);
//     }
// }
