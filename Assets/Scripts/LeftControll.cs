using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class LeftControll : MonoBehaviour
{
    public XRController xrcontrol;
    void Update()
    {
        float f;

        xrcontrol.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out f);


        if (f >= 0.9)
        {
            
        }
    }
}
