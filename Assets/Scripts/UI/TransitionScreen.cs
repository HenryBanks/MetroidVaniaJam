using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionScreen : MonoBehaviour
{
    public static TransitionScreen instance;

    public CanvasGroup canvasGroup;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void OnEnable()
    {
        Debug.Log("TransitionScreen OnEnable called");
        instance = this;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Fade(bool fadeIn)
    {
        if (fadeIn)
        {
            canvasGroup.alpha = 1f;
            StartCoroutine(FadeIn(100));
        }
        else
        {
            canvasGroup.alpha = 0f;
            StartCoroutine(FadeOut(100));
        }
    }

    IEnumerator FadeIn(int steps)
    {
        for (int f = 0; f <= steps; f++)
        {
            canvasGroup.alpha -= 1f / steps;
            yield return null;
        }
    }

    IEnumerator FadeOut(int steps)
    {
        for (int f = 0; f <= steps; f++)
        {
            canvasGroup.alpha += 1f / steps;
            yield return null;
        }
    }

}
