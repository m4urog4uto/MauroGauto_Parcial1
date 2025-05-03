using UnityEngine;

public class PickupHealth : MonoBehaviour
{
    PlayerBase player;

    void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<PlayerBase>();
        if (player != null)
        {
            player.RestoreHealth();
            Destroy(gameObject);
        }
    }
}
