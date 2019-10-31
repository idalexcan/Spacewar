using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    GameObject tofollow, heroship;
    void Awake()
    {
        tofollow=GameObject.Find("Followpoint");
        heroship=GameObject.Find("HeroShip");
    }

    void Update()
    {
        /*transform.position=tofollow.transform.position;
        /*if ((tofollow.transform.position-transform.position).magnitude>1)
        {
            transform.position+=(tofollow.transform.position-transform.position).normalized*Heroship.speed*0.92f;
        }
        transform.LookAt(heroship.transform.position);*/
    }
}
