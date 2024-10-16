using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public ExtinguisherControll Extinguisher;
    RectTransform trans;

    float speed = 0.4f;
    void Start()
    {
        trans = GetComponent<RectTransform>();
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0);

        if (trans.position.y <= 1.4f)
        {
            speed *= -1;
        }

        if (trans.position.y >= 1.8f)
        {
            speed *= -1;
        }

        transform.Translate(0f, speed * Time.deltaTime, 0f);
    }

    public void disappear()
    {
        gameObject.SetActive(false);
    }
}
