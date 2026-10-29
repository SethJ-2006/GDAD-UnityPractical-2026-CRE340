using UnityEngine;
using PrimeTween;

public class SpawnPopOvershoot : MonoBehaviour
{
    [Header("Pop - Overshoot")]
    public float duration = 0.3f;
    public Ease ease = Ease.OutBack;
    public float startDelay = 0f; // staggers

    private Vector3 fullSize;

    private void Awake()
    {
        fullSize = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    private void Start()
    {
        Sequence.Create()
            .Chain(Tween.Scale(transform, endValue: fullSize * 1.3f, duration: duration * 0.6f, ease: Ease.OutQuad))
            .Chain(Tween.Scale(transform, endValue: fullSize, duration: duration * 0.4f, ease: Ease.OutQuad));
        // Chain runs a tween after the previous one finishes
        // Group would run it at the same time, useful for scaling and spinning at once.
    }
}
