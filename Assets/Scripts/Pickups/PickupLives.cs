using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PickupLives : MonoBehaviour
{
    PlayerBase player;

    void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<PlayerBase>();
        Debug.Log(player.GetLives());
        if (player != null && player.GetLives() == 0)
        {
            player.AddLive();
            Destroy(gameObject);
        }
    }
}