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

    [Header("Aiming Weapons")]
    [SerializeField] private Transform weaponPosition;

    [Header("Right Hand Target")]
    [SerializeField] private TwoBoneIKConstraint rightHandIK;
    [SerializeField] private Transform rightHandTarget;

    [Header("Left Hand Target")]
    [SerializeField] private TwoBoneIKConstraint leftHandIK;
    [SerializeField] private Transform leftHandTarget;

    void FixedUpdate()
    {
        RaycastHandler();
        PickupWeapon();
    }

    private void RaycastHandler()
    {
        Ray topRay = new Ray(transform.position + rayOffset, transform.forward);
        Physics.Raycast(topRay, out topRayHitInfo, rayLength, weaponMask);
    }

    private void PickupWeapon()
    {
        if (topRayHitInfo.collider != null)
        {
            IWeapon weapon = topRayHitInfo.transform.gameObject.GetComponent<IWeapon>();
            if (weapon != null)
            {
                weapon.PickupWeapon(leftHandTarget, rightHandTarget);
                ActivateAnimations();
            }
            else
            {
                leftHandIK.weight = 0f;
                rightHandIK.weight = 0f;
            }
        }
    }

    void ActivateAnimations()
    {
        leftHandIK.weight = 1f;
        rightHandIK.weight = 1f;

        SetAnimationIsArmed(true);
    }
}