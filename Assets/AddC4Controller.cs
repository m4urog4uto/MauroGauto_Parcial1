using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddC4Controller : MonoBehaviour
{
    [Header("Ray Settings")]

    [SerializeField][Range(0.06f, 0.5f)] private float rayLength;
    [SerializeField] private Vector3 rayOffset;
    [SerializeField] private LayerMask weaponMask;
    private RaycastHit topRayHitInfo;

    [SerializeField] CounterTimerC4 counterTimerC4;

    void FixedUpdate()
    {
        RaycastHandler();
        AddC4();
    }

    private void RaycastHandler()
    {
        Ray topRay = new Ray(transform.position + rayOffset, transform.forward);
        // Debug.DrawRay(topRay.origin, topRay.direction * rayLength, Color.red);
        Physics.Raycast(topRay, out topRayHitInfo, rayLength, weaponMask);
    }

    private void AddC4()
    {
        if (topRayHitInfo.collider != null)
        {
            RadioEnemy radioEnemy = topRayHitInfo.transform.gameObject.GetComponent<RadioEnemy>();
            if (radioEnemy != null && !counterTimerC4.GetTimerActive())
            {
                radioEnemy.DestroyRadioByC4();
            }
        }
    }
}
