public static class HealthEventManager
{
    public delegate void HealthEvent(string name, int currentHealth);
    public static HealthEvent OnObjectDamaged;
    public static HealthEvent OnObjectDestroyed;
}
