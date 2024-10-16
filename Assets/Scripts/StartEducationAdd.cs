using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartEducationAdd : MonoBehaviour
{
    public CanvasGroup canvasdelta;
    public CanvasGroup canvasalpha;

    bool sw = false;
    private void Start()
    {
        StartCoroutine(StartScene());
    }

    public void NextScene()
    {
        if (sw == false)
        {
            sw = true;
            StartCoroutine(NextScenee());
        }

    }

    IEnumerator StartScene()
    {
        for (int i = 100; i >= 0; i--)
        {
            RenderSettings.skybox.SetFloat("_Exposure", (100 - i) / 100f);
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(1f);

        for(int i = 0; i < 100; i++)
        {
            canvasdelta.alpha = i / 100f;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(2f);

        for (int i = 100; i >= 0; i--)
        {
            canvasdelta.alpha = i / 100f;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(1f);

        for (int i = 0; i <= 100; i++)
        {
            canvasalpha.alpha = i / 100f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator NextScenee()
    {
        for (int i = 100; i >= 0; i--)
        {
            canvasalpha.alpha = i / 100f;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(1f);

        for (int i = 0; i <= 100; i++)
        {
            RenderSettings.skybox.SetFloat("_Exposure", (100 - i) / 100f);
            yield return new WaitForSeconds(0.01f);
        }

        SceneManager.LoadScene("TutorialScene");
    }
}
