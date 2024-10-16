using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypingTextother2 : MonoBehaviour
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
        text.text = "";

        for (int i = 0; i < lines[typelinecnt].Length; i++)
        {
            yield return new WaitForSeconds(0.1f);
            sound.Play();
            text.text += lines[typelinecnt][i];
        }

        if (text.text.EndsWith("방법을")) //text 마지막 글자를 검사해 특정 단어가 나오면 줄바꿈 추가
        {
            text.text += "\n";
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
