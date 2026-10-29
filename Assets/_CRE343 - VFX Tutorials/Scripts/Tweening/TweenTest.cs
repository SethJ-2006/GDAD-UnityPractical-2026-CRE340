using UnityEngine;
using PrimeTween;

public class TweenTest : MonoBehaviour
{
    private void Start()
    {
        // Scale to double
        Tween.Scale(transform, endValue: Vector3.one * 2f, duration: 1f, ease: Ease.OutBack);
    }
}
