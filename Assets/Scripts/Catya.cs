using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catya : Enemy
 {
    int  changespeed;
    public GameObject heroship, endPoint, catyanes;


    private void Awake()
    {
        enemyType=EnemyType.catya;
        // para obtener los puntos del catyroad 
    }

    void Update()
    {
        catyanes.transform.position=transform.position;
        catyanes.transform.Rotate(transform.up*1.8f);
        Conduct();
    }

    void Conduct() // COMPORTAMIENTO DE CATYA
    {
        // Movimiento
        transform.LookAt(endPoint.transform.position);
        GetComponent<Rigidbody>().velocity= transform.forward * speed;
        
        // Cambio de velocidad
        changespeed++;
        if (changespeed==200)
        {
            float heroSpeedT=heroship.GetComponent<Heroship>().speed;
            speed=Random.Range(heroSpeedT*0.8f, heroSpeedT*1.8f);
            changespeed=0;
        }
    }
 }
