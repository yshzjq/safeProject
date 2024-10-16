using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class TutorialScripts : MonoBehaviour
{
    public GameObject notification;
    public Animator notificationAnimate;
    public TextMeshProUGUI text;


    public List<string> sentens = new List<string>();

    int sentensidx = -1;
    int sentenscnt;

    float waitTime = 2f;

    void Start() // ó�� Ʃ�丮�� ����
    {
        sentenscnt = sentens.Count;
        StartCoroutine(FirstNotification());
    }
    IEnumerator FirstNotification() // 5�� �ڿ� ó�� Ʃ�丮�� ���� ��Ÿ��
    {
        yield return new WaitForSeconds(3f);
        notificationAnimate.SetBool("appear",true);
        StartCoroutine(StartTypeReady());
    }

    IEnumerator StartTypeReady()
    {
        sentensidx = -1;
        sentenscnt = sentens.Count;
        yield return new WaitForSeconds(waitTime);
        //notificationAnimate.SetTrigger("appear");

        StartCoroutine(TypingTexting());
    } // Ÿ���� �غ�

    IEnumerator TypingTexting()
    {
        sentensidx++;

        Debug.Log(sentensidx);

        if (sentensidx == sentenscnt)
        {
            notificationAnimate.SetBool("appear",false);
            yield return new WaitForSeconds(0.05f);
            text.text = "";
            StopAllCoroutines();
            yield return null;
        }

        foreach(char c in sentens[sentensidx])
        {
            text.text += c;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(2f);

        text.text = "";

        StartCoroutine(TypingTexting());
    } // ����Ʈ�� �־��� �ؽ�Ʈ ���

    public void NotificationMessageAppear(List<string> _sentens, float _waitTime)
    {
        StopAllCoroutines();
        sentens = _sentens;
        waitTime = _waitTime;
        sentensidx = -1;
        sentenscnt = sentens.Count;
        text.text = "";
        notificationAnimate.SetBool("appear",true);
        StartCoroutine(StartTypeReady());
    }

}
