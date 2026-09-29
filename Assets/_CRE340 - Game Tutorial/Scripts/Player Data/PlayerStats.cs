using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private PlayerData data = new PlayerData();

    public PlayerData Data
    {
        get { return data;}
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
}
