using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IWeapon
{
    public void PickupWeapon(Transform aimingSpawn, Transform leftHandTarget, Transform rightHandTarget);
}