using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] int _bulletDamage = 20;
    [SerializeField] float _bulletSpeed;
    bool hasCollided = false;

    PlayerBase playerBase;
    Shield shield;
    Rigidbody rb;
    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * _bulletSpeed;
        Destroy(gameObject, 2f);
    }

    public void OnCollisionEnter(Collision collision)
    {
        // TODO: Refactor
        if (collision.gameObject.tag == "Player")
        {
            if (hasCollided) return;
            hasCollided = true;
            playerBase = collision.gameObject.GetComponent<PlayerBase>();
            playerBase.TakeDamage(_bulletDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "RadioEnemy")
        {
            if (hasCollided) return;
            hasCollided = true;
            shield = collision.gameObject.GetComponent<Shield>();
            shield.TakeDamage(_bulletDamage);
            Destroy(gameObject);
        }
    }
}
