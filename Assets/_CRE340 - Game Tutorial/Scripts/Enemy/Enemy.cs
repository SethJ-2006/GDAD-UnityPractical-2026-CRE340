using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [Header("Enemy Data")]
    public EnemyData enemyData;

    // public int health = 10;
    private int health;
    public int Health
    {
        get { return health; }
    }

    private Material mat;
    private Color originalColor;

    private void Awake()
    {
        if (enemyData == null)
        {
            Debug.LogError("Enemy on " + gameObject.name + "has no EnemyData assigned!");
            return;
        }

        health = enemyData.startingHealth;
        gameObject.name = enemyData.enemyName;

        mat = GetComponent<Renderer>().material;
        mat.color = enemyData.enemyColor;
        originalColor = mat.color;
    }

    private void Update()
    {
        // Ask the GameManager where the player is.
        // There might not be one - not spawned yet, or dead - so check before using it.
        if (GameManagerWeek5.Instance.Player == null)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            GameManagerWeek5.Instance.Player.transform.position,
            enemyData.moveSpeed * Time.deltaTime
        );
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (HealthEventManager.OnObjectDamaged != null)
        {
            HealthEventManager.OnObjectDamaged(gameObject.name, health);
        }

        if (health <= 0)
        {
            if (HealthEventManager.OnObjectDestroyed != null)
            {
                HealthEventManager.OnObjectDestroyed(gameObject.name, health);
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
        GameManagerWeek5.Instance.AddXP(enemyData.xpValue);
        Destroy(gameObject);
    }

    [Header("Contact Damage")]
    public float damageCooldown = 1f;
    private float lastDamageTime = -100f;

    private void OnCollisionStay(Collision collision)
    {
        if (Time.time < lastDamageTime + damageCooldown)
        {
            return;
        }

        if (collision.gameObject.TryGetComponent<PlayerStats>(out PlayerStats playerStats))
            {
                playerStats.TakeDamage(enemyData.contactDamage);
                playerStats.ShowHitEffect();

                lastDamageTime = Time.time;
            }
    }    
}

