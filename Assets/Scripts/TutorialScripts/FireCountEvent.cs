using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCountEvent : MonoBehaviour
{
    public int firecount;

    public TutorialScripts tutorial;

    public List<string> messages = new List<string>();

    public GameObject pointer;

    public int pointerappeardelaytime;


    // Start is called before the first frame update

    public void OutFire()
    {
        firecount--;

        if(firecount == 0 )
        {
            OutFireEvent();
        }
    }// 주변 불이 다 꺼지면 OutFireEvent 실행

    public void OutFireEvent() // 메세지 출력 및 화살표 출력
    {
        tutorial.NotificationMessageAppear(messages, 2f);

        StartCoroutine(pointerAppear());
    }

    IEnumerator pointerAppear()
    {
        yield return new WaitForSeconds(pointerappeardelaytime);
        pointer.SetActive(true);
    }


}
