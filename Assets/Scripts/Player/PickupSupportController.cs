using UnityEngine;

public class PickupSupportController : MonoBehaviour
{
    [SerializeField] private Transform supportSpawn;

    private void OnTriggerEnter(Collider other)
    {
        IPickupSupport support = other.GetComponent<IPickupSupport>();
        if (support != null)
        {
            if (supportSpawn != null && supportSpawn.childCount > 0)
            {
                Destroy(supportSpawn.GetChild(0).gameObject);
            }
            support.PickupSupport(supportSpawn);
            BoxCollider supportCollider = supportSpawn.GetChild(0).gameObject.GetComponent<BoxCollider>();
            supportCollider.isTrigger = false;
        }
    }
}
