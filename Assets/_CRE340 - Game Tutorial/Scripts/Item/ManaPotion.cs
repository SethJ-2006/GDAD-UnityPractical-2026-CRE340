using UnityEngine;

public class ManaPotion : Item
{
    [Header("Mana Potion")]
    public int manaRecoverAmount;
    public int minRecoverAmount = 10;
    public int maxRecoverAmount = 50;

    protected override void Awake()
    {
        base.Awake();

        data = new ItemData("Mana Potion", "A potion that replenishes Mana.");

        manaRecoverAmount = Random.Range(minRecoverAmount, maxRecoverAmount);

        Debug.Log("ManaPotion: random recover amount set to " + manaRecoverAmount);
    }

    public override void Use(PlayerStats player)
    {
        Debug.Log("Mana Potion used - recovering " + manaRecoverAmount + " mana.");
        player.RecoverMana(manaRecoverAmount);
    }
}
