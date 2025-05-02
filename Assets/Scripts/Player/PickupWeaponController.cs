using UnityEngine.Animations.Rigging;
using UnityEngine;

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

    [Header("IK Shotgun Hands Target")]
    [SerializeField] private Transform IKRightHandPosShotgun;
    [SerializeField] private Transform IKLeftHandPosShotgun;

    [Header("IK Pistol Hands Target")]
    [SerializeField] private Transform IKRightHandPosPistol;
    [SerializeField] private Transform IKLeftHandPosPistol;


    void Update()
    {
        leftHandIK.weight = 0f;
        if (shotgun != null)
        {
            if (aimingPistolSpawn != null && aimingPistolSpawn.childCount > 0)
            {
                Destroy(aimingPistolSpawn.GetChild(0).gameObject);
            }

            shotgun.transform.SetParent(aimingShotgunSpawn.transform);
            shotgun.transform.position = aimingShotgunSpawn.position;
            shotgun.transform.rotation = aimingShotgunSpawn.rotation;

            SetAnimationIsArmed(true);

            leftHandIK.weight = 1f;
            leftHandTarget.position = IKLeftHandPosShotgun.position;
            leftHandTarget.rotation = IKLeftHandPosShotgun.rotation;

            rightHandIK.weight = 1f;
            rightHandTarget.position = IKRightHandPosShotgun.position;
            rightHandTarget.rotation = IKRightHandPosShotgun.rotation;
            shotgun.isAiming(true);
        }
        else if (pistol != null)
        {
            if (aimingShotgunSpawn != null && aimingShotgunSpawn.childCount > 0)
            {
                Destroy(aimingShotgunSpawn.GetChild(0).gameObject);
            }

            pistol.transform.parent = aimingPistolSpawn.transform;
            pistol.transform.position = aimingPistolSpawn.position;
            pistol.transform.rotation = aimingPistolSpawn.rotation;

            SetAnimationIsArmed(true);

            leftHandIK.weight = 1f;
            leftHandTarget.position = IKLeftHandPosPistol.position;
            leftHandTarget.rotation = IKLeftHandPosPistol.rotation;

            rightHandIK.weight = 1f;
            rightHandTarget.position = IKRightHandPosPistol.position;
            rightHandTarget.rotation = IKRightHandPosPistol.rotation;
            pistol.isAiming(true);
        }
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
