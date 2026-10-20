using UnityEngine;

public class GameManagerWeek5 : MonoBehaviour
{
    #region Singleton


    private static GameManagerWeek5 instance;


    public static GameManagerWeek5 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<GameManagerWeek5>();

                if (instance == null)
                {
                    Debug.LogError("This Scene appears to be missing a Game Manager. Please add one");
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogWarning("A second Game Manager is detected. Destroying it");
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    #endregion

    #region Progression

    [Header("Progression")]
    [SerializeField] private int coins = 0;
    [SerializeField] private int xp = 0;

    public int Coins
    {
        get { return coins; }
    }
    public int XP
    {
        get { return xp;  }
    }

    public void AddCoins(int amount)
    {
        coins = coins + amount;
        Debug.Log("Coins: " + coins);
    }

    public void AddXP(int amount)
    {
        xp = xp + amount;
        Debug.Log("Exp. Points: " + xp);
    }

    #endregion

    #region Player Reference

    private PlayerStats player;

    public PlayerStats Player
    {
        get { return player; }
    }

    public void RegisterPlayer(PlayerStats newPlayer)
    {
        player = newPlayer;
    }

    #endregion
}
