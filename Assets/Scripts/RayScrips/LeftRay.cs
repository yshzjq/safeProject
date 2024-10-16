using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class LeftRay : MonoBehaviour
{
    public XRController xrcontrol;

    public GameObject fireExtingusherGuidemessage;
    public CanvasGroup canvasGroup;

    // Start is called before the first frame update
    private void Update()
    {
        float f;

        xrcontrol.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out f);

        if (f >= 0.9)
        {
            RaycastHit hit;

            if(Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.collider.tag == "FireExtinguisher")
                {
                    StartCoroutine(appearGuideMessage());
                }
            }
        }
    }
    IEnumerator appearGuideMessage()
    {
        fireExtingusherGuidemessage.SetActive(true);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j <= 50; j++)
            {
                canvasGroup.alpha = j / 50f;
                yield return new WaitForSeconds(0.001f);
            }

            for (int j = 50; j >= 0; j--)
            {
                canvasGroup.alpha = j / 50f;
                yield return new WaitForSeconds(0.001f);
            }

        }

        fireExtingusherGuidemessage.SetActive(false);
    }
        
}
