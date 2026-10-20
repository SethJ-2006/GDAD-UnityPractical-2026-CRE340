using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        get { return xp; }
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

    #region Player Spawning
    [Header("Player")]
    public GameObject playerPrefab;
    public Transform playerSpawnPoint;
    public float respawnDelay = 2f;

    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        if (playerPrefab == null || playerSpawnPoint == null)
        {
            Debug.LogError("Player cannot be spawned in. Please check to see if either the Player Prefab or the Player Spawn Point is empty.");
            return;
        }

        Instantiate(playerPrefab, playerSpawnPoint.position, playerSpawnPoint.rotation);
    }

    [Header("Lives")]
    [SerializeField] private int lives = 3;

    public int Lives
    {
        get { return lives; }
    }

    public void PlayerDied()
    {
        lives = lives - 1;
        Debug.Log("Player has died. Lives remaining: " + lives);

        if (lives > 0)
        {
            StartCoroutine(RespawnAfterDelay());
        }
        else
        {
            GameOver();
        }
    }

    private IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(respawnDelay);
        SpawnPlayer();
    }

    #endregion

    #region Game State

    [Header("Game State")]
    [SerializeField] private bool isGameOver = false;
    public float restartDelay = 5f;

    public bool IsGameOver
    {
        get { return isGameOver; }
    }

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("GAME OVER - Coins collected: " + coins + " | Total XP: " + xp);

        StartCoroutine(RestartAfterDelay());
    }

    private IEnumerator RestartAfterDelay()
    {
        yield return new WaitForSeconds(restartDelay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    #endregion
}
