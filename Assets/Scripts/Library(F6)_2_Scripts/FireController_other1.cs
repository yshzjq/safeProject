using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController_other1 : MonoBehaviour
{
    bool isWaterting = false;
    bool isFire = true;
    public float fireExitPower;

    public FireCountEvent_other1 fireCountEvent;

    void Update()
    {

        if (isWaterting == true)
        {
            transform.localScale -= new Vector3(fireExitPower, fireExitPower, fireExitPower);
        }

        if (transform.localScale.x <= 0.1f)
        {
            fireCountEvent.OutFire();
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water")
        {
            isWaterting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Water")
        {
            isWaterting = false;
        }
    }
}
