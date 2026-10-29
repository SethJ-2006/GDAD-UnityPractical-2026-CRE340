using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using PrimeTween;

public class ScreenDamageEffects : MonoBehaviour
{
    public Volume volume;

    [Header("Damage Flash")]
    public float flashStrength = 0.6f;
    public float flashUp = 0.05f;
    public float flashDown = 0.4f;

    private Vignette vignette;
    private int lastHealth = -1;

    private void Awake()
    {
        if (volume != null)
        {
            volume.profile.TryGet(out vignette);
        }
    }

    private void OnEnable()
    {
        UIEventManager.OnHealthChanged += HandleHealthChanged;
    }
    private void OnDisable()
    {
        UIEventManager.OnHealthChanged -= HandleHealthChanged;
    }

    private void HandleHealthChanged(int current, int max)
    {
        if (lastHealth >= 0 && current < lastHealth)
        {
            FlashDamage();
        }

        lastHealth = current;
    }

    private void FlashDamage()
    {
        if (vignette == null)
        {
            return;
        }

        Sequence.Create()
            .Chain(Tween.Custom(0f, flashStrength, duration: flashUp,
                onValueChange: value => vignette.intensity.value = value))
            .Chain(Tween.Custom(flashStrength, 0f, duration: flashDown,
                onValueChange: value => vignette.intensity.value = value));
    }
}
