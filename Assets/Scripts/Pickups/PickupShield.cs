using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PickupShield : MonoBehaviour
{
    PlayerBase player;
    Rigidbody pickupBody;
    [SerializeField] private float rotationSpeed = 10;

    void Start()
    {
        pickupBody = GetComponent<Rigidbody>();

        if (pickupBody)
        {
            pickupBody.isKinematic = true;
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<PlayerBase>();
        if (player != null)
        {
            player.AddProtection();
            Destroy(gameObject);
        }
    }
}