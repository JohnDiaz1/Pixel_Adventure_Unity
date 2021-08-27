using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    [SerializeField]
    float duration;
    [SerializeField]
    float delay;

    [SerializeField]
    AnimationCurve animationCurve;
    [SerializeField]
    RectTransform target;

    [SerializeField]
    Vector2 startPoint;
    [SerializeField]
    Vector2 finalPoint;
    Coroutine currentAnimation;

    public bool isPlaying => currentAnimation != null;

    [ContextMenu("Fade In")]
    public void FadeIn()
    {
        if (currentAnimation == null)
        {
            currentAnimation = StartCoroutine(FadeInCoroutine(startPoint, finalPoint));
        }
    }

    [ContextMenu("Fade Out")]
    public void FadeOut()
    {
        if (currentAnimation == null)
        {
            currentAnimation = StartCoroutine(FadeInCoroutine(finalPoint, startPoint));
        }
    }

    IEnumerator FadeInCoroutine(Vector2 a, Vector2 b)
    {
        Vector2 startPoint = a;
        Vector2 finalPoint = b;
        float elapsed = 0;
        while (elapsed <= delay)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0;
        while (elapsed <= duration)
        {
            float percentage = elapsed / duration;
            float curvePercentage = animationCurve.Evaluate(percentage);
            elapsed += Time.deltaTime;
            Vector2 currentPosition = Vector2.Lerp(startPoint, finalPoint, curvePercentage);
            target.anchoredPosition = currentPosition;
            yield return null;
        }

        target.anchoredPosition = finalPoint;
        currentAnimation = null;

    }
}
