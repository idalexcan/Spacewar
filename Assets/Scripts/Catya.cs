using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catya : MonoBehaviour
{
    public GameObject forward;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(forward.transform.position);
        GetComponent<Rigidbody>().velocity=transform.forward*speed;
        ForwardControl();
    }
    int timer;
    float change;
    void ForwardControl()
    {
        timer++;
        if (timer==change)
        {
            float giroy=Random.Range(-20,20), girox=Random.Range(-20,20);
            transform.eulerAngles+=new Vector3(girox,giroy,0);
            //forward.transform.localPosition=new Vector3(Random.Range(-5,5),Random.Range(-5,5),forward.transform.localPosition.z);
            speed=Random.Range(400,1000);
            timer=0;
            change=Random.Range(500,1000);
        }
        
    }
}
