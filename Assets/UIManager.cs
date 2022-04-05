using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float duration;
    private bool isAnimating = false;

    private int isActivated = 1;

    [SerializeField]
    private Image toggleButton;
    [SerializeField]
    private GameObject buttonCircle;

    [SerializeField]
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = buttonCircle.transform.localPosition;
        endPosition = -buttonCircle.transform.localPosition;
        duration = 0.2f;
        button.onClick.AddListener(StartAnimation);
    }

    private void StartAnimation()
    {
        if (isAnimating) return;

        Vector3 pos = buttonCircle.transform.localPosition;

        StartCoroutine(LinearInterpolation(pos.x, -pos.x, duration));
        toggleButton.color = (isActivated == 1) ? Color.gray : Color.green;
        isActivated *= -1;
    }

    IEnumerator LinearInterpolation(float startPosition, float endPosition, float duration)
    {
        isAnimating = true;
        // 22C31A
        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            buttonCircle.transform.localPosition = new Vector3(Mathf.Lerp(startPosition, endPosition, timeElapsed / duration), 0, 0);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        buttonCircle.transform.localPosition = new Vector3(endPosition, 0, 0);
        isAnimating = false;
    }
}
