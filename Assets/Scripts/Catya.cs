using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catya : Enemy
{
    public GameObject brujula;
    public static Vector3[] roadPoints;
    int contPoints=0;

    private void Awake()
    {
        Transform tempT = GameObject.Find("Catyaroad").transform;
        roadPoints = new Vector3[tempT.childCount];
        for (int i = 0, j = 0; i < tempT.childCount; i++, j = j + 40) 
        {
            //tempT.GetChild(i).transform.localPosition.
            roadPoints[i] = tempT.GetChild(i).transform.position;
            
        }
    }

    void Start()
    {
        
    }

    //Vector3 tempTarget;
    void Update()
    {
        if (contPoints<roadPoints.Length)
        {
            if ((roadPoints[contPoints] - transform.position).magnitude > 20)
            {
                transform.LookAt(roadPoints[contPoints]);

                //transform.LookAt(Vector3.Lerp(transform.eulerAngles,road);
                GetComponent<Rigidbody>().velocity= transform.forward * speed*50;
                transform.position += (roadPoints[contPoints] - transform.position).normalized * speed;
            }
            else
            {
                contPoints++;
            }
        }
    }

    int timer;
    float change;
    void ForwardControl()
    {
        
        
    }
}
