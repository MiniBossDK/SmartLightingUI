using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    private Transform startPosition;
    private Transform endPosition;
    private float duration;

    float lerpDuration = 3;
    float startValue = 0;
    float endValue = 10;
    float valueToLerp;

    enum InterpolationType
    {
        Ease_In,
        Ease_Out,
        Linear,
    }

    private void Start()
    {
        
    }

    IEnumerator Linear()
    {
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            valueToLerp = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        valueToLerp = endValue;
    }
}
