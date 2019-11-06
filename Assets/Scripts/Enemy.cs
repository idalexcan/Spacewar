using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject cube;
    public float speed;
    


    void Start()
    {
        /*cube=GameObject.Find("Cube");
        for (int i = 0; i < 400; i++)
        {
            GameObject clon=Instantiate(cube);
            clon.transform.position=new Vector3(Random.Range(-300,300),Random.Range(-400,400),Random.Range(20,15000));
        }*/

        //print(roadPoints.Length);
    }


    void Update()
    {
        
    }
}


        /*Transform tempT = GameObject.Find("Warapo").transform;

        childs = new GameObject[tempT.childCount];

        for (int i = 0; i < tempT.childCount; i++)
        {
            childs[i] = tempT.GetChild(i).gameObject;
        }*/
