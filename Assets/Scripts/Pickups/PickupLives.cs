using UnityEngine;
public class PickupLives : MonoBehaviour
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
        if (player != null && GameManager.Instance.Lives < 3)
        {
            player.AddLive();
            Destroy(gameObject);
        }
    }
}