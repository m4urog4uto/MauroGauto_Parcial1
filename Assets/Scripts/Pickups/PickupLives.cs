using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PickupLives : MonoBehaviour
{
    PlayerBase player;

    void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<PlayerBase>();
        if (player != null && player.Lives == 0)
        {
            player.AddLive();
            Destroy(gameObject);
        }
    }
}