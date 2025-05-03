using UnityEngine;

public class BulletTurret : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 10f;
    [SerializeField] int _bulletDamage = 10;
    PlayerBase playerBase;
    Rigidbody rb;
    bool hasCollided = false;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();

        // TODO: Agregar Delta Time
        rb.velocity = transform.forward * _bulletSpeed;
        Destroy(gameObject, 2f);
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
    }
}