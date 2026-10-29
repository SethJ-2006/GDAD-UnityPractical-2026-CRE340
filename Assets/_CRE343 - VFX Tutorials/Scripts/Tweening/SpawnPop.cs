using UnityEngine;
using PrimeTween;

public class SpawnPop : MonoBehaviour
{
    [Header("Pop")]
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
        Tween.Scale(transform, endValue: fullSize, duration: duration, ease: ease, startDelay: startDelay);
    }
}
