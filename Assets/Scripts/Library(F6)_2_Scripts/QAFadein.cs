using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QAFadein : MonoBehaviour
{
    CanvasGroup canvasGroup;
    private void OnEnable()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(FadeinStart());
    }
    IEnumerator FadeinStart()
    {
        for(int i = 0;i<=50;i++)
        {
            canvasGroup.alpha = i/50f;
            yield return new WaitForSeconds(0.01f);
        }
    }

}
