using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class EnemyShoot : MonoBehaviour
{
    [Header("Right Hand Target")]
    [SerializeField] private TwoBoneIKConstraint rightHandIK;
    [SerializeField] private Transform rightHandTarget;

    [Header("Left Hand Target")]
    [SerializeField] private TwoBoneIKConstraint leftHandIK;
    [SerializeField] private Transform leftHandTarget;

    [Header("IK Rifle Hands Target")]
    [SerializeField] GameObject weapon;
    [SerializeField] private Transform IKRightHandPosRifle;
    [SerializeField] private Transform IKLeftHandPosRifle;
    void Update()
    {
        if (weapon != null)
        {
            leftHandTarget.position = IKLeftHandPosRifle.position;
            leftHandTarget.rotation = IKLeftHandPosRifle.rotation;

            rightHandTarget.position = IKRightHandPosRifle.position;
            rightHandTarget.rotation = IKRightHandPosRifle.rotation;
        }
    }
}