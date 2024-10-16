using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnsScripts : MonoBehaviour
{

    CanvasGroup canvasGroup;

    void OnEnable()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        StartCoroutine(fadein());
    }

    public void Restart()
    {
        canvasGroup.alpha = 0f;
        gameObject.SetActive(false);
    }

    IEnumerator fadein()
    {
        for(int i = 0;i<=50;i++)
        {
            canvasGroup.alpha = i / 50f;
            yield return new WaitForSeconds(0.05f);
        }

    }

}
