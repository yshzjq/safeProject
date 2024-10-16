using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goto3FElveator : MonoBehaviour
{
    float bigXScale;
    float bigYScale;
    float bigZScale;
    
    private void Start()
    {
        bigXScale = transform.localScale.x;
        bigYScale = transform.localScale.y;
        bigZScale = transform.localScale.z;
    }
    public void GoPlace()
    {
        SceneManager.LoadScene("Elevator_Front(F3)");
    }

    public void bigBlink()
    {
        transform.localScale = new Vector3(bigXScale, bigYScale, bigZScale);
    }
}
