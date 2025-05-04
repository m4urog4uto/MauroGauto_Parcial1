using UnityEngine;

public class BulletEnemy1 : MonoBehaviour
{
    int _bulletDamage = 20;
    float _bulletSpeed = 10;
    bool hasCollided = false;

    PlayerBase playerBase;
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
        else if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Floor" || collision.gameObject.tag == "RadioEnemy")
        {
            Destroy(gameObject);
        }
    }
}
