using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IDamagable
{
    [SerializeField] private PlayerData data = new PlayerData();

    public PlayerData Data
    {
        get { return data;}
    }

    public int Health
    {
        get { return data.currentHealth; }
    }

    private Material mat;
    private Color originalColor;

    private void Awake()
    {
        GameManagerWeek5.Instance.RegisterPlayer(this);
    }
    
    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        originalColor = mat.color;
    }

    public void RestoreHealth(int amount)
    {
        data.currentHealth = data.currentHealth + amount;

        data.currentHealth = Mathf.Clamp(data.currentHealth, 0, data.maximumHealth);

        Debug.Log("Player health is now " + data.currentHealth + " / " + data.maximumHealth);
    }

    public void RecoverMana(int amount)
    {
        data.currentMana = data.currentMana + amount;

        data.currentMana = Mathf.Clamp(data.currentMana, 0, data.maximumMana);

        Debug.Log("Player mana is now " + data.currentMana + " / " + data.maximumMana);
    }

    public void TakeDamage(int damage)
    {
        data.currentHealth = data.currentHealth - damage;
        data.currentHealth = Mathf.Clamp(data.currentHealth, 0, data.maximumHealth);

        if (HealthEventManager.OnObjectDamaged != null)
        {
            HealthEventManager.OnObjectDamaged(gameObject.name, data.currentHealth);
        }

        if (data.currentHealth <= 0)
        {
            Die();
        }
    }

    public void ShowHitEffect()
    {
        StartCoroutine(FlashColour(Color.white));
    }

    private IEnumerator FlashColour(Color flashColour)
    {
        mat.color = flashColour;
        yield return new WaitForSeconds(0.1f);
        mat.color = originalColor;
    }

    private void Die()
    {
        if (HealthEventManager.OnObjectDestroyed != null)
        {
            HealthEventManager.OnObjectDestroyed(gameObject.name, data.currentHealth);
        }

        Debug.Log("Player has died!");

        // TODO in week 5
    }
}
