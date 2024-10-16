using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneGo : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    int sw = 0;
    public void GoPlace()
    {
        if(sw == 0)
        {
            StartCoroutine(endProcess());
            sw = 1;
        }
        
    }

    IEnumerator endProcess()
    {
        for (int i = 0; i <= 100; i++)
        {
            RenderSettings.skybox.SetFloat("_Exposure", 1 + i / 100f);
            yield return new WaitForSeconds(0.01f);
        }

        for (int i = 0; i <= 100; i++)
        {
            canvasGroup.alpha = i / 100f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}