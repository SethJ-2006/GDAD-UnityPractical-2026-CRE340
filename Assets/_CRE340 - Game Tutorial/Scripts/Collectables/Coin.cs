using UnityEngine;

public class Coin : Item
{
    [Header("Coin")]
    public int coinValue = 1;

    protected override void Awake()
    {
        base.Awake();

        data = new ItemData("Coin", "Money can be exchanged for goods and services.");
    }


    public override void Use(PlayerStats player)
    {
        Debug.Log("Picked up a coin worth " + coinValue);

        GameManagerWeek5.Instance.AddCoins(coinValue);
    }
}
