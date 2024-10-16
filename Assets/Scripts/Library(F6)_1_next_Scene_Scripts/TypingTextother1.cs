using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TypingTextother1 : MonoBehaviour
{
    TextMeshProUGUI text;
    AudioSource sound;

    public List<string> lines = new List<string>();

    public GameObject canvas;

    int textcnt;
    int typelinecnt = -1;
    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        sound = GetComponent<AudioSource>();

        textcnt = lines.Count;

        StartCoroutine(StartText());
    }

    IEnumerator StartText()
    {
        typelinecnt++;

        if (typelinecnt == lines.Count)
        {
            yield return new WaitForSeconds(1f);
            canvas.SetActive(true);
            yield break;
        }

        for (int i = 0; i < 2; i++)
        {
            sound.Play();
            text.text = "_";
            yield return new WaitForSeconds(0.4f);
            text.text = " ";
            yield return new WaitForSeconds(0.4f);
        }

        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        for (int i = 0; i < lines[typelinecnt].Length; i++)
        {
            yield return new WaitForSeconds(0.1f);
            sound.Play();
            text.text += lines[typelinecnt][i];
        }

        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(0.4f);
            sound.Play();
            text.text += "_";
            yield return new WaitForSeconds(0.4f);
            text.text = text.text.Remove(text.text.Length - 1);
        }

        StartCoroutine(DeleteText());
    }

    IEnumerator DeleteText()
    {
        for (int i = lines[typelinecnt].Length - 1; i >= 0; i--)
        {
            text.text = text.text.Remove(i);
            yield return new WaitForSeconds(0.05f);
        }

        StartCoroutine(StartText());
    }
}
