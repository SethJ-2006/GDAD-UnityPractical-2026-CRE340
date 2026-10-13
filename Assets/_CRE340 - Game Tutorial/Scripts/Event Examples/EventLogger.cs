using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class EventLogger : MonoBehaviour
{
    [Header("UI Log")]
    public TextMeshProUGUI logText;
    public int maxLines = 10;


    private List<string> logLines = new List<string>();

    private void OnEnable()
    {
        HealthEventManager.OnObjectDamaged += HandleObjectDamaged;
        HealthEventManager.OnObjectDestroyed += HandleObjectDestroyed;
    }

    private void OnDisable()
    {
        HealthEventManager.OnObjectDamaged -= HandleObjectDamaged;
        HealthEventManager.OnObjectDestroyed -= HandleObjectDestroyed;
    }

    private void HandleObjectDamaged(string name, int remainingHealth)
    {
        // Debug.Log("EVENT LISTENER SAYS: An object named " + name + " was damaged! Remaining health: " + remainingHealth);
        string message = name + " was damaged - health now remaining: " + remainingHealth;

        Debug.Log(message);
        AddToLog(message);
    }

    private void HandleObjectDestroyed(string name, int remainingHealth)
    {
        // Debug.Log("EVENT LISTENER SAYS: An object named " + name + " has been destroyed!");
        string message = name + " has been destroyed!";

        Debug.Log(message);
        AddToLog(message);
    }

    private void AddToLog(string message)
    {
        if (logText == null)
        {
            return;
        }

        logLines.Add(message);

        if (logLines.Count > maxLines)
        {
            logLines.RemoveAt(0);
        }

        logText.text = string.Join("\n", logLines);
    }
}
