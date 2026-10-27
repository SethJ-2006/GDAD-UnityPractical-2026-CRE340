using UnityEngine;

public class HUDPresenter : MonoBehaviour
{
    public HUDView view;

    private void OnEnable()
    {
        UIEventManager.OnHealthChanged += HandleHealthChanged;
        UIEventManager.OnManaChanged += HandleManaChanged;
        UIEventManager.OnCoinsChanged += HandleCoinsChanged;
        UIEventManager.OnXPChanged += HandleXPChanged;
        UIEventManager.OnLivesChanged += HandleLivesChanged;
        UIEventManager.OnGameOver += HandleGameOver;
    }
    private void OnDisable()
    {
        UIEventManager.OnHealthChanged -= HandleHealthChanged;
        UIEventManager.OnManaChanged -= HandleManaChanged;
        UIEventManager.OnCoinsChanged -= HandleCoinsChanged;
        UIEventManager.OnXPChanged -= HandleXPChanged;
        UIEventManager.OnLivesChanged -= HandleLivesChanged;
        UIEventManager.OnGameOver -= HandleGameOver;
    }

    private void Start()
    {
        RefreshAll();
    }    

    private void RefreshAll()
    {
        view.ShowCoins(GameManager.Instance.Coins);
        view.ShowXP(GameManager.Instance.XP);
        view.ShowLives(GameManager.Instance.Lives);
    }

    private void HandleHealthChanged(int current, int max)
    {
        view.ShowHealth(current, max);
    }
    private void HandleManaChanged(int current, int max)
    {
        view.ShowMana(current, max);
    }
    private void HandleCoinsChanged(int value)
    {
        view.ShowCoins(value);
    }
    private void HandleXPChanged(int value)
    {
        view.ShowXP(value);
    }
    private void HandleLivesChanged(int value)
    {
        view.ShowLives(value);
    }
    private void HandleGameOver()
    {
        view.ShowGameOver();
    }
}
