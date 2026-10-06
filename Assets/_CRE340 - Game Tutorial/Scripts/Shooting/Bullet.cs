using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.linearVelocity = Vector3.zero;
        rb.useGravity = true;

        if (collision.gameObject.TryGetComponent<IDamagable>(out IDamagable damageable))
        {
            // Add deciding what we hit in the future
            damageable.TakeDamage(damage);
            damageable.ShowHitEffect();

            Debug.Log("Hit something - " + damageable.Health + " health remaining!");
        }
    }
}
