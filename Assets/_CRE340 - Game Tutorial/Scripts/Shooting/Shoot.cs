using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("Input Manager Reference")]
    public InputManager inputManager;

    [Space(10)]

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    public float bulletSpeed = 20f;
    public float shootCooldown = 0.2f;

    private float lastShootTime = -100f;

    void Start()
    {
        if (bulletSpawnPoint == null)
        {
            bulletSpawnPoint = new GameObject().transform;
            bulletSpawnPoint.name = "Bullet Spawn Point";
            bulletSpawnPoint.parent = transform;
            bulletSpawnPoint.localPosition = new Vector3(0f, 0.2f, 1f);
            bulletSpawnPoint.localRotation = Quaternion.identity;
        }
    }

    void Update()
    {
        if (inputManager.ButtonWest.Pressed() && Time.time > lastShootTime + shootCooldown)
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        Vector3 bulletDirection = transform.forward;
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        if (bulletRb != null)
        {
            bulletRb.linearVelocity = bulletDirection * bulletSpeed;
        }

        lastShootTime = Time.time;
    }
}
