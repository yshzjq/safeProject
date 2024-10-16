using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoPointerAppear : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    private void OnEnable()
    {
        StartCoroutine(FadeInStart());
    }
    IEnumerator FadeInStart()
    {
        for (int i = 0; i <= 100; i++)
        {
            yield return new WaitForSeconds(0.1f);
            canvasGroup.alpha = i / 100f;
        }
    }
}
