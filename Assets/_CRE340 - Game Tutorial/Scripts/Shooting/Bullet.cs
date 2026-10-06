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

        // TODO: PART 2!
    }
}
