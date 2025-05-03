using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;
    public float aimInfluence = 2f;
    public Vector3 aimDirection;

    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 aimOffset = new Vector3(aimDirection.x, aimDirection.y, 0f) * aimInfluence;
            Vector3 targetCamPos = desiredPosition + aimOffset;

            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime); 
        }
    }
}
