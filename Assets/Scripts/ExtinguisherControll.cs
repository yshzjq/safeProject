using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguisherControll : MonoBehaviour
{
    public ExtingusherArrowScripts extingusherArrowScripts;

    public bool isHodingExitinguisher = false;

    public List<string> sentens = new List<string>();

    public GameObject ExitinguisherHose;
    public RightRay right;

    public TutorialScripts TutorialScripts;

    public bool isNotice = false;

    public void holdingExitinguisher()
    {
        //Debug.Log("소화기 들었다");
        isHodingExitinguisher = true;
        ExitinguisherHose.SetActive(true);
        right.holdingHose();
    }

    public void unholdingExtinguisher()
    {
        //Debug.Log("소화기 내렸다");
        isHodingExitinguisher = false;
        ExitinguisherHose.SetActive(false);
        right.unholdingHose();
    }

    public void noticeAppear()
    {
        if (isNotice == false && sentens.Count > 0)
        {
            isNotice = true;
            extingusherArrowScripts.DestroyArrowObject();
            TutorialScripts.NotificationMessageAppear(sentens, 1f);
        }
        
    }
}
