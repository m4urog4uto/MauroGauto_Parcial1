using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class TurningController : MonoBehaviour
{
    [SerializeField] LayerMask floorMask;
    Rigidbody playerRigidBody;
    float camRayLenght = 100f;

    Ray camRay;
    RaycastHit floorHit;
    Vector3 playerToMouse;

    void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Turning();
    }

    void Turning()
    {
        camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(camRay, out floorHit, camRayLenght, floorMask))
        {
            if (floorHit.collider.CompareTag("Enemy"))
            {
                Vector3 direction = (floorHit.transform.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f);
            }
            else
            {
                playerToMouse = floorHit.point - transform.position;
                playerToMouse.y = 0f;

                Quaternion newRotation = Quaternion.LookRotation(playerToMouse, Vector3.up);
                playerRigidBody.MoveRotation(newRotation);
            }

        }
    }
}
