using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PickupWeaponController : MonoBehaviour
{
    [SerializeField] private Transform weaponSpawn;

    private void OnTriggerEnter(Collider other)
    {

        IWeapon weapon = other.GetComponent<IWeapon>();
        if (weapon != null)
        {
            if (weaponSpawn != null && weaponSpawn.childCount > 0)
            {
                Destroy(weaponSpawn.GetChild(0).gameObject);
            }
            weapon.PickupWeapon(weaponSpawn);
        }
    }
}
