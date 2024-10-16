using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appear : MonoBehaviour
{
    // Start is called before the first frame update
    public float waitTime;

    public GameObject appearas;
    void Start()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(waitTime);
        appearas.SetActive(true);
    }
}
