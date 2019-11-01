using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    GameObject toLook, heroship;
    float speed=0;

    public float offsetX;
    public float offsetY;
    public float offsetZ;

    public float smoothSpeed;
    void Awake()
    {
        toLook=GameObject.Find("Forward");
        heroship=GameObject.Find("HeroShip");
        
    }

    void Update()
    {
        
        

        /*speed=heroship.GetComponent<Rigidbody>().velocity.magnitude*2;
        //transform.position+=
        GetComponent<Rigidbody>().velocity=(toLook.transform.position-transform.position).normalized*speed;
        //GetComponent<Rigidbody>().AddForce((toLook.transform.position-transform.position).normalized*speed);
        if ((heroship.transform.position-transform.position).magnitude>25)
        {
            
        }
        if (Input.GetMouseButton(0))
        {
            
            
            //GetComponent<Rigidbody>().AddForce(transform.forward*speed);
        }
        else
        {
            
        }
        transform.LookAt(heroship.transform.position);*/
    }
}
