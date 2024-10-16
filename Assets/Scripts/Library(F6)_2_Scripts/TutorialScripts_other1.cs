using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class TutorialScripts_other1 : MonoBehaviour
{
    public GameObject notification;
    public Animator notificationAnimate;
    public TextMeshProUGUI text;

    public GameObject Question;

    public List<string> sentens = new List<string>();

    bool doQuestion = true;

    int sentensidx = -1;
    int sentenscnt;

    float waitTime = 2f;

    void Start() // 처음 튜토리얼 시작
    {
        sentenscnt = sentens.Count;
        StartCoroutine(FirstQuestion());
    }
    IEnumerator FirstQuestion() // 5초 뒤에 처음 튜토리얼 공지 나타남
    {
        yield return new WaitForSeconds(3f);
        notificationAnimate.SetBool("appear", true);
        StartCoroutine(StartTypeReady());
    }

    IEnumerator StartTypeReady()
    {
        sentensidx = -1;
        sentenscnt = sentens.Count;
        yield return new WaitForSeconds(waitTime);
        //notificationAnimate.SetTrigger("appear");

        if(doQuestion == true)
        {
            doQuestion = false;
            // 코루틴
            StartCoroutine(TypingTextingQA());
        }
        else
        {
            StartCoroutine(TypingTexting());
        }
        
    } // 타이핑 준비

    IEnumerator TypingTexting()
    {
        sentensidx++;

        if (sentensidx == sentenscnt)
        {
            notificationAnimate.SetBool("appear", false);
            yield return new WaitForSeconds(0.05f);
            text.text = "";
            StopAllCoroutines();
            yield return null;
        }

        foreach (char c in sentens[sentensidx])
        {
            text.text += c;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(2f);

        text.text = "";

        StartCoroutine(TypingTexting());
    } // 리스트에 넣어진 텍스트 출력

    IEnumerator TypingTextingQA() // 질문 출력
    {
        sentensidx++;


        if (sentensidx == sentenscnt)
        {
            yield return new WaitForSeconds(0.05f);
            text.text = "";
            Question.SetActive(true);
            StopAllCoroutines();
            yield return null;
        }

        foreach (char c in sentens[sentensidx])
        {
            text.text += c;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(2f);

        text.text = "";

        StartCoroutine(TypingTextingQA());
    } // 리스트에 넣어진 텍스트 출력

    public void NotificationMessageAppear(List<string> _sentens, float _waitTime)
    {
        StopAllCoroutines();
        sentens = _sentens;
        waitTime = _waitTime;
        sentensidx = -1;
        sentenscnt = sentens.Count;
        text.text = "";
        notificationAnimate.SetBool("appear", true);
        StartCoroutine(StartTypeReady());
    }
}
