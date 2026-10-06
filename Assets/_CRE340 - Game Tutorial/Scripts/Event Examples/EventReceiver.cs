using System.Collections;
using UnityEditorInternal;
using UnityEngine;

public class EventReceiver : MonoBehaviour
{
    private Vector3 originalScale;
    private void OnEnable()
    {
        EventSender.OnFire += HandleFireEvent;
    }

    private void OnDisable()
    {
        EventSender.OnFire -= HandleFireEvent;
    }

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void HandleFireEvent(float scale, float speed)
    {
        StartCoroutine(ScaleObject(scale, speed));
    }


    private IEnumerator ScaleObject(float targetScale, float speed)
    {
        Vector3 targetSize = originalScale * targetScale;
        float elapsedTime = 0f;
        float duration = 1f / speed;

        while (elapsedTime < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetSize, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetSize;
        elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.localScale = Vector3.Lerp(targetSize, originalScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = originalScale;
    }
}
