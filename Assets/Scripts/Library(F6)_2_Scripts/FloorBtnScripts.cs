using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBtnScripts : MonoBehaviour
{
    public TutorialScripts_other1 noticeMessage;

    public GameObject falseObject;

    public List<string> noticeList = new List<string>();

    public void sendNoticeMassage()
    {
        noticeMessage.NotificationMessageAppear(noticeList, 1f);
        falseObject.SetActive(false);
    }
}
