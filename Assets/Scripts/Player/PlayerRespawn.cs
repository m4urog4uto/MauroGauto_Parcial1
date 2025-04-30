using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 respawnPosition;
    void Start()
    {
        GameObject point = GameObject.Find("RespawnPoint");
        if (point != null)
        {
            respawnPosition = point.transform.position;
        }
    }

    public void Respawn()
    {
        CharacterController cc = GetComponent<CharacterController>();
        cc.enabled = false;
        transform.position = respawnPosition;
        cc.enabled = true;
    }
}
