using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class fadeinother1 : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(FadeInStart());
    }

    IEnumerator FadeInStart()
    {
        for (int i = 100; i >= 0; i--)
        {
            RenderSettings.skybox.SetFloat("_Exposure", (100 - i) / 100f);
            yield return new WaitForSeconds(0.01f);
        }

        SceneManager.LoadScene("Library(F6)_2");
    }



}
