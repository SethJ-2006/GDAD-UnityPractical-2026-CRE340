using UnityEngine;
using TMPro;

public class CoinDisplayPolling : MonoBehaviour
{
    private TextMeshProUGUI coinText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        coinText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    private void Update()
    {
        coinText.text = "Coins: " + GameManagerWeek5.Instance.Coins;
    }
}
