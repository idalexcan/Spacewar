using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Catyan : Enemy 
 {
    public GameObject endPoint, back, catyanStone;
    public int timerLimit=10, timer=0;
    

    void Awake()
    {
        back=transform.GetChild(1).gameObject;
    }

    void Update()
    {
        transform.LookAt(endPoint.transform.position); 

        

        timer++;
        if (timer>=timerLimit)
        {
            GameObject stone=Instantiate(catyanStone);
            stone.transform.position=back.transform.position;
            stone.AddComponent<Proyectile>().type=TypeProyectile.catyanStone;
            timer=0;
            timerLimit=Random.Range(10,200);
        }
    }
 }
