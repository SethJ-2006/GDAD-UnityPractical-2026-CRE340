using UnityEngine;
using Unity.Cinemachine;

public class CameraShake : MonoBehaviour
{
    [Header("Impulse")]
    public CinemachineImpulseSource impulseSource;

    [Header("Strength")]
    public float fireShake = 0.1f;
    public float killShake = 0.5f;

    private void Awake()
    {
        if (impulseSource == null)
        {
            impulseSource = GetComponent<CinemachineImpulseSource>();
        }
    }

    private void OnEnable()
    {
        EventBus<WeaponFired>.Subscribe(HandleWeaponFired);
        EventBus<EnemyKilled>.Subscribe(HandleEnemyKilled);
    }
    private void OnDisable()
    {
        EventBus<WeaponFired>.Unsubscribe(HandleWeaponFired);
        EventBus<EnemyKilled>.Unsubscribe(HandleEnemyKilled);
    }

    private void HandleWeaponFired(WeaponFired message)
    {
        if (impulseSource == null)
        {
            return;
        }

        impulseSource.transform.position = message.position;

        Vector3 kick = -message.direction * fireShake;

        impulseSource.GenerateImpulse(kick);
        // Shake(message.position, fireShake);
    }
    private void HandleEnemyKilled(EnemyKilled message)
    {
        Shake(message.position, killShake);
    }

    private void Shake(Vector3 position, float strength)
    {
        if (impulseSource == null)
        {
            return;
        }

        impulseSource.transform.position = position;

        impulseSource.GenerateImpulse(strength);
    }
}
