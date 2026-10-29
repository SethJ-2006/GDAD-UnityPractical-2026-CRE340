using UnityEngine;
using PrimeTween;

public class UIPunch : MonoBehaviour
{
    public Transform coinTarget;
    public Transform xpTarget;

    [Header("Punch")]
    public float punchStrength = 0.25f;
    public float duration = 0.3f;
    public float frequency = 5f;

    private void OnEnable()
    {
        UIEventManager.OnCoinsChanged += HandleCoinsChanged;
        UIEventManager.OnXPChanged += HandleXPChanged;
    }
    private void OnDisable()
    {
        UIEventManager.OnCoinsChanged -= HandleCoinsChanged;
        UIEventManager.OnXPChanged -= HandleXPChanged;
    }

    private void HandleCoinsChanged(int value)
    {
        Punch(coinTarget);
    }
    private void HandleXPChanged(int value)
    {
        Punch(xpTarget);
    }

    private void Punch(Transform target)
    {
        if (target == null)
        {
            return;
        }

        Tween.StopAll(onTarget: target);
        target.localScale = Vector3.one;

        Tween.PunchScale(target, strength: Vector3.one * punchStrength,
            duration: duration, frequency: frequency);
    }
}
