using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

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
