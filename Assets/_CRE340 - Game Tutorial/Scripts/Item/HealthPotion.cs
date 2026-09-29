using UnityEngine;

public class HealthPotion : Item
{
    [Header("Health Potion")]
    public int healthRestoreAmount;
    public int minRestoreAmount = 25;
    public int maxRestoreAmount = 75;

    protected override void Awake()
    {
        base.Awake();

        data = new ItemData("Health Potion", "A potion that restores health.");

        healthRestoreAmount = Random.Range(minRestoreAmount, maxRestoreAmount);

        Debug.Log("HealthPotion: random restore amount set to " + healthRestoreAmount);
    }

    public override void Use(PlayerStats player)
    {
        Debug.Log("Health Potion used - restoring " + healthRestoreAmount + " health.");
        player.RestoreHealth(healthRestoreAmount);
    }
}
