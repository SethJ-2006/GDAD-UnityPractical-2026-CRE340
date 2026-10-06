using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    public int health = 10;

    public int Health
    {
        get { return health; }
    }

    private Material mat;
    private Color originalColor;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        originalColor = mat.color;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (HealthEventManager.OnObjectDamaged != null)
        {
            HealthEventManager.OnObjectDamaged(health);
        }

        if (health <= 0)
        {
            if (HealthEventManager.OnObjectDestroyed != null)
            {
                HealthEventManager.OnObjectDestroyed(health);
            }
            Die();
        }
    }

    public void ShowHitEffect()
    {
        StartCoroutine(FlashColor(Color.softRed));
    }

    private IEnumerator FlashColor(Color flashColor)
    {
        mat.color = flashColor;
        yield return new WaitForSeconds(0.1f);

        mat.color = originalColor;
    }

    private void Die()
    {
        // TODO in later weeks
        Destroy(gameObject);
    }
}

