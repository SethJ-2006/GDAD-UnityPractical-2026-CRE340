using UnityEngine;
using PrimeTween;

public class TweenTest : MonoBehaviour
{
    private void Start()
    {
        // Scale to double
        Tween.Scale(transform, endValue: Vector3.one * 2f, duration: 1f, ease: Ease.OutElastic);

        // OutBack = Overshoots and settles back in, a 'pop' or explosion of sorts.
        // Linear = Constant speed, more mechanical.
        // InQuad = Slow and speeds up over time
        // OutQuad = Fast but slows down over time
        // OutElastic = Wobbles to a stop. Bouncy surfaces/objects, more cartoonish motion.
        // OutBounce = Bounces to a stop. Like an object on a string.
    }
}
