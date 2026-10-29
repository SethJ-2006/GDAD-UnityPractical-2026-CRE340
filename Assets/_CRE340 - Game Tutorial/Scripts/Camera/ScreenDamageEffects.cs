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

    [Header("Aberration")]
    public float aberrationStrength = 0.3f;

    private ChromaticAberration aberration;

    [Header("Game Over")]
    public float desaturateTime = 5f;

    private ColorAdjustments colorAdjustments;

    private Vignette vignette;
    private int lastHealth = -1;

    private void Awake()
    {
        if (volume != null)
        {
            volume.profile.TryGet(out vignette);
            volume.profile.TryGet(out aberration);
            volume.profile.TryGet(out colorAdjustments);
        }
    }

    private void OnEnable()
    {
        UIEventManager.OnHealthChanged += HandleHealthChanged;
        UIEventManager.OnGameOver += HandleGameOver;
    }
    private void OnDisable()
    {
        UIEventManager.OnHealthChanged -= HandleHealthChanged;
        UIEventManager.OnGameOver -= HandleGameOver;
    }

    private void HandleHealthChanged(int current, int max)
    {
        if (lastHealth >= 0 && current < lastHealth)
        {
            FlashDamage();
        }

        lastHealth = current;
    }

    private void HandleGameOver()
    {
        if (colorAdjustments == null)
        {
            return;
        }

        Tween.Custom(0f, -100f, duration: desaturateTime,
            onValueChange: value => colorAdjustments.saturation.value = value);
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

        if (aberration != null)
        {
            Sequence.Create()
                .Chain(Tween.Custom(0f, aberrationStrength, duration: flashUp,
                    onValueChange: value => aberration.intensity.value = value))
                .Chain(Tween.Custom(aberrationStrength, 0f, duration: flashDown * 1.5f,
                    onValueChange: value => aberration.intensity.value = value));
        }
    }



}
