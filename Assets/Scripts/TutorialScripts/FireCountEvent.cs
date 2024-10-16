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
    }// �ֺ� ���� �� ������ OutFireEvent ����

    public void OutFireEvent() // �޼��� ��� �� ȭ��ǥ ���
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
