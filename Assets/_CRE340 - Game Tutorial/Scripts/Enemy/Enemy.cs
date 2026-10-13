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
    private Transform playerTransform;

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

    private void Start()
    {
        PlayerStats player = FindFirstObjectByType<PlayerStats>();

        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                playerTransform.position,
                enemyData.moveSpeed * Time.deltaTime
            );
        }
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
        // TODO in week 5.
        Destroy(gameObject);
    }
}

