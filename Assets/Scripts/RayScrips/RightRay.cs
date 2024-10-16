using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class RightRay : MonoBehaviour
{
    public XRController xrcontrol;

    public GameObject WaterSpawn;

    bool isExtingusherhand = false;

    bool shoot = false;
    
    public void holdingHose()
    {
        isExtingusherhand = true;
    }

    public void unholdingHose()
    {
        isExtingusherhand = false;
    }


    void Update()
    {
        float f;

        xrcontrol.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out f);

        xrcontrol.inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out shoot);

        if(f >= 0.9 && isExtingusherhand == true && shoot == true)
        {
            //Debug.Log("소화기 발사");
            WaterSpawn.SetActive(true);

        }
        else if(f >= 0.9 && isExtingusherhand == true && shoot == false)
        {
            //Debug.Log("소화기 끄기");
            WaterSpawn.SetActive(false);
        }
        else if (f >= 0.9)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {

                if (hit.collider.tag == "EL1FAR")
                {
                    GotoElveator gotoElveator = hit.collider.GetComponent<GotoElveator>();
                    gotoElveator.GoPlace();
                }
                else if (hit.collider.tag == "EL3FAR")
                {
                    Goto3FElveator gotoElveator = hit.collider.GetComponent<Goto3FElveator>();
                    gotoElveator.GoPlace();
                }
                else if(hit.collider.tag == "EL6FAR")
                {
                    Goto6FElveator gotoElveator = hit.collider.GetComponent<Goto6FElveator>();
                    gotoElveator.GoPlace();
                }
                else if (hit.collider.tag == "Library_1F")
                {
                    GotoLibraryNextStation gotoElveator = hit.collider.GetComponent<GotoLibraryNextStation>();
                    gotoElveator.GoPlace();
                }
                else if (hit.collider.tag == "GotoLibrary(F6)_2")
                {
                    GotoLibraryNextStation gotoElveator = hit.collider.GetComponent<GotoLibraryNextStation>();
                    gotoElveator.GoPlace();
                }
                else if (hit.collider.tag == "End")
                {
                    EndSceneGo gotoElveator = hit.collider.GetComponent<EndSceneGo>();
                    gotoElveator.GoPlace();
                }
                else if (hit.collider.tag == "nextScene1F")
                {
                    GotoLobby1F gotoElveator = hit.collider.GetComponent<GotoLobby1F>();
                    gotoElveator.GoPlace();
                }
            }
        }
    }
}
