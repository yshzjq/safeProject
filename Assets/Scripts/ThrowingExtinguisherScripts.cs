using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingExtinguisherScripts : MonoBehaviour
{
    Rigidbody throwingFireExtingusher;

    public float magnificentThrowForce;

    public GameObject Effect;

    public Moving moving;

    Vector3 myPos;

    Vector3 gravity;

    bool isuse = false;

    void Start()
    {
        throwingFireExtingusher = GetComponent<Rigidbody>();
        myPos = transform.position;
    }

    private void Update()
    {
        gravity = throwingFireExtingusher.velocity;
    }

    public void GetGravity()
    {
        if(moving != null) moving.disappear();

        StartCoroutine(UseGravity());
    }

    IEnumerator UseGravity()
    {
        throwingFireExtingusher.AddForce(gravity * 2f, ForceMode.Force);
        yield return new WaitForSeconds(0.2f);
        throwingFireExtingusher.AddForce(gravity * 2f,ForceMode.Force);
    }

    void boom()
    {
        if (isuse == false)
        {
            StopAllCoroutines();
            isuse = true;   

            Instantiate(Effect, transform.position, Quaternion.identity);
            gameObject.SetActive(false);

            refill();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Plane" || collision.collider.tag == "Fire")
        {
            boom();
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
    }
    void refill()
    {
        StopAllCoroutines();
        isuse = false;

        gameObject.transform.position = myPos;  
        gameObject.transform.rotation = Quaternion.Euler(0,0,0);

        gameObject.SetActive(true);

    }
}
