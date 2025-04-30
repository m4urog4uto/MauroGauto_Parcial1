using UnityEngine;

public class BulletGun : MonoBehaviour
{
    public float _bulletDamage;
    public float _bulletSpeed;

    Rigidbody rb;

    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody>();

        // TODO: Agregar Delta Time
        rb.velocity = transform.forward * _bulletSpeed;
        Destroy(gameObject, 2f);
    }

    public void OnCollisionEnter(Collision collision)
    {
        IDamageEnemy damageEnemy = collision.gameObject.GetComponent<IDamageEnemy>();
        if (damageEnemy != null)
        {
            damageEnemy.TakeDamage(_bulletDamage);
            Destroy(gameObject);
        }
    }

}
