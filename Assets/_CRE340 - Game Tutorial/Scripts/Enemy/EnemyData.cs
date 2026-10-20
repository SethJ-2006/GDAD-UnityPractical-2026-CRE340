using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "CRE340 - Game Tutorial/Enemy Data")]
public class EnemyData : ScriptableObject
{
    [Header("Identity")]
    public string enemyName = "Bad Guy";
    public Color enemyColor = Color.mediumVioletRed;

    [Header("Stats")]
    public int startingHealth = 10;
    public float moveSpeed = 2f;
    public int contactDamage = 5;

    [Header("Rewards")]
    [FormerlySerializedAs("scoreValue")]
    public int xpValue = 10;
}
