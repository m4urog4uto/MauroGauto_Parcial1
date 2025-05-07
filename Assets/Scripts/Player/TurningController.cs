using UnityEngine;

public class TurningController : MonoBehaviour
{
    [SerializeField] LayerMask floorMask;
    float camRayLenght = 100f;

    Ray camRay;
    RaycastHit floorHit;
    Vector3 playerToMouse;

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
                transform.rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y - 28f, 0f);
            }
            else
            {
                playerToMouse = floorHit.point - transform.position;
                playerToMouse.y = 0f;

                Quaternion newRotation = Quaternion.LookRotation(playerToMouse, Vector3.up);
                transform.rotation = newRotation;
            }

        }
    }
}
