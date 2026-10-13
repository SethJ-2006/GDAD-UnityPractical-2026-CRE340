using UnityEngine;

public class EventListener : MonoBehaviour
{
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
        Debug.Log("EVENT LISTENER SAYS: An object named " + name + " was damaged! Remaining health: " + remainingHealth);
    }

    private void HandleObjectDestroyed(string name, int remainingHealth)
    {
        Debug.Log("EVENT LISTENER SAYS: An object named " + name + " has been destroyed!");
    }
}
