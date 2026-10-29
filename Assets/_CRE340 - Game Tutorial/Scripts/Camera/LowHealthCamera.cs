using UnityEngine;
using Unity.Cinemachine;
using PrimeTween;

public class LowHealthCamera : MonoBehaviour
{
    public CinemachineBasicMultiChannelPerlin noise;

    [Header("Tuning")]
    public float threshold = 0.3f;
    public float maxAmplitude = 0.5f;
    public float blendTime = 0.4f;

    private void Awake()
    {
        if (noise == null)
        {
            noise = GetComponent<CinemachineBasicMultiChannelPerlin>();
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
        if (noise == null || max <= 0)
        {
            return;
        }

        float fraction = (float)current / (float)max;
        float target = 0f;

        if (fraction < threshold)
        {
            float amount = 1f - (fraction / threshold);
            target = maxAmplitude * amount;
        }

        Tween.Custom(noise.AmplitudeGain, target, duration: blendTime,
            onValueChange: value => noise.AmplitudeGain = value);
    }
}
