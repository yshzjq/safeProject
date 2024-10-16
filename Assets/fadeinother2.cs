using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fadeinother2 : MonoBehaviour
{
    // Start is called before the first frame update
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

        SceneManager.LoadScene("EndScene");
    }
}
