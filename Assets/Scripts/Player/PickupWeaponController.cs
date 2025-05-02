using UnityEngine.Animations.Rigging;
using UnityEngine;

public class PickupWeaponController : PlayerBase
{
    [Header("Ray Settings")]

    [SerializeField][Range(0.06f, 0.5f)] private float rayLength;
    [SerializeField] private Vector3 rayOffset;
    [SerializeField] private LayerMask weaponMask;
    private RaycastHit topRayHitInfo;

    private IWeapon weapon;

    [SerializeField] private Transform aimingWeaponSpawn;

    private bool isAiming = false;

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
        if (weapon != null)
        {
            // weapon.transform.parent = aimingWeaponSpawn.transform;
            // weapon.transform.position = aimingWeaponSpawn.position;
            // weapon.transform.rotation = aimingWeaponSpawn.rotation;

            weapon.PickupWeapon(aimingWeaponSpawn);
            
            isAiming = true;
            SetAnimationIsArmed(true);
        }
        if (!isAiming)
        {
            leftHandIK.weight = 0f;
        }
        else
        {
            leftHandIK.weight = 1f;
            leftHandTarget.position = IKLeftHandPosShotgun.position;
            leftHandTarget.rotation = IKLeftHandPosShotgun.rotation;

            rightHandIK.weight = 1f;
            rightHandTarget.position = IKRightHandPosShotgun.position;
            rightHandTarget.rotation = IKRightHandPosShotgun.rotation;
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
            weapon = topRayHitInfo.transform.gameObject.GetComponent<IWeapon>();
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
