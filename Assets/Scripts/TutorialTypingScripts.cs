using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialTypingScripts : MonoBehaviour
{
    public List<string> sentens = new List<string>();

    public float waitTime;

    public TextMeshProUGUI text;

    int sentenscnt;
    int sentensidx = -1;

    public void StartNoticeMessage()
    {
        sentenscnt = sentens.Count;
        int sentensidx = -1;

        StartCoroutine(StartTypeReady());
    }
    public void NoticeMessage(List<string> sentens)
    {
        sentenscnt = sentens.Count;
        int sentensidx = -1;

        text = GetComponent<TextMeshProUGUI>();

        StartCoroutine(StartTypeReady());
    }

    private void Start()
    {
        sentenscnt = sentens.Count;

        StartCoroutine(WaitDelay());
    }

    IEnumerator WaitDelay()
    {
        yield return new WaitForSeconds(waitTime);

        StartCoroutine(StartTypeReady());
    }

    IEnumerator StartTypeReady()
    {
        sentensidx++;

        if(sentensidx == sentenscnt)
        {
            yield break;
        }

        StartCoroutine(TypingText());
    }

    IEnumerator TypingText()
    {
        for (int i = 0; i < sentens[sentensidx].Length; i++)
        {

            text.text += sentens[sentensidx][i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(2f);

        text.text = "";

        StartCoroutine(StartTypeReady());
    }
}
