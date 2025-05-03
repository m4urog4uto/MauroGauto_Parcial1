using UnityEngine;

public class GranadeEnemy : MonoBehaviour
{
    public float _bulletDamage;
    public float _bulletSpeed;
    private float forceMultiplier = 7f;
    PlayerBase playerBase;
    private GameObject player;

    // TODO: Ta mal, granada es un script aparte
    [SerializeField] private GameObject granade;
    bool hasCollided = false;




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        // TODO: Error con Rb llamado multiples veces
        Rigidbody rb;
        rb = GetComponent<Rigidbody>();
        Vector3 forceDirection = (player.transform.position - transform.position).normalized;
        rb.AddForce((forceDirection + Vector3.up) * forceMultiplier, ForceMode.VelocityChange);
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
        Destroy(gameObject);
    }

    void Update()
    {
        
        Destroy(gameObject, 3f);
    }

    public void Shoot(GameObject granadeSpawn)
    {
        Instantiate(granade, granadeSpawn.transform.position, granadeSpawn.transform.rotation);
    }
}
