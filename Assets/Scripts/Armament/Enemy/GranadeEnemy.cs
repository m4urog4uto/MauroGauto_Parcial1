using UnityEngine;

public class GranadeEnemy : MonoBehaviour
{
    public float _bulletDamage;
    public float _bulletSpeed;
    PlayerBase playerBase;
    private GameObject player;
    bool hasCollided = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        Rigidbody rb;
        rb = GetComponent<Rigidbody>();

        float distance = Vector3.Distance(player.transform.position, transform.position);

        float minDistance = 5f;
        float midDistance = 18f;
        float maxDistance = 14f;

        float closeForce = 5f;
        float midForce = 10f;
        float farForce = 14f;

        float forceToApply;

        if (distance <= minDistance)
        {
            forceToApply = closeForce;
        }
        else if (distance <= midDistance)
        {
            float t = Mathf.InverseLerp(minDistance, midDistance, distance);
            forceToApply = Mathf.Lerp(closeForce, midForce, t);
        }
        else if (distance <= maxDistance)
        {
            float t = Mathf.InverseLerp(midDistance, maxDistance, distance);
            forceToApply = Mathf.Lerp(midForce, farForce, t);
        }
        else
        {
            forceToApply = farForce;
        }

        Vector3 forceDirection = (player.transform.position - transform.position).normalized;
        rb.AddForce((forceDirection + Vector3.up) * forceToApply, ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (hasCollided) return;
            hasCollided = true;
            playerBase = collision.gameObject.GetComponent<PlayerBase>();
            playerBase.TakeDamage(_bulletDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Floor" || collision.gameObject.tag == "RadioEnemy")
        {
            Destroy(gameObject);
        }
    }
}
