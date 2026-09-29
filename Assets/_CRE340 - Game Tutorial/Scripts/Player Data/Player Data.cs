[System.Serializable]
public class PlayerData
{
    public int currentHealth;
    public int maximumHealth;
    public int currentMana;
    public int maximumMana;

    public PlayerData()
    {
        currentHealth = 50;
        maximumHealth = 100;
        currentMana = 20;
        maximumMana = 100;
    }

    public PlayerData(int startingHealth, int startingMana)
    {
        currentHealth = startingHealth;
        maximumHealth = 100;
        currentMana = startingMana;
        maximumMana = 100;
    }
}
