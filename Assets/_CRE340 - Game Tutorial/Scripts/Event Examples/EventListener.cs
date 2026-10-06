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

    private void HandleObjectDamaged(int remainingHealth)
    {
        Debug.Log("EVENT LISTENER SAYS: An object was damaged! Remaining health: " + remainingHealth);
    }

    private void HandleObjectDestroyed(int remainingHealth)
    {
        Debug.Log("EVENT LISTENER SAYS: An object has been destroyed!");
    }
}
