using UnityEngine;

public class Shotgun : MonoBehaviour, IWeapon
{
    [SerializeField] private Shotgun weapon;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnBullet;
    
    [Header("Weapons Spawner")]
    [SerializeField] private Transform weaponPositions;
    [SerializeField] private Transform aimingShotgunSpawn;

    [Header("IK Shotgun Hands Target")]
    [SerializeField] private Transform IKRightHandPosShotgun;
    [SerializeField] private Transform IKLeftHandPosShotgun;

    private float timerShoot = 0;
    private float timeBetweenShoot = 1;
    private bool isPickupWeapon = false;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        timerShoot += Time.deltaTime;
        if (Input.GetButton("Fire1") && timerShoot > timeBetweenShoot && isPickupWeapon && spawnBullet != null && bullet != null)
        {
            audioSource.Play();
            Instantiate(bullet, spawnBullet.transform.position, spawnBullet.transform.rotation);
            timerShoot = 0f;
        }
    }
    public void isAiming(bool value)
    {
        isPickupWeapon = value;
    }

    public void PickupWeapon(Transform leftHandTarget, Transform rightHandTarget)
    {
        Transform spawnPistol = weaponPositions.GetChild(1);
        if (spawnPistol.childCount > 0)
        {
            Transform weapon = spawnPistol.GetChild(0);
            Destroy(weapon.gameObject);
        }

        transform.SetParent(aimingShotgunSpawn.transform);
        transform.position = aimingShotgunSpawn.position;
        transform.rotation = aimingShotgunSpawn.rotation;

        leftHandTarget.position = IKLeftHandPosShotgun.position;
        leftHandTarget.rotation = IKLeftHandPosShotgun.rotation;

        rightHandTarget.position = IKRightHandPosShotgun.position;
        rightHandTarget.rotation = IKRightHandPosShotgun.rotation;

        isAiming(true);
    }
}
