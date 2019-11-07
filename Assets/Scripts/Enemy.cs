﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    catya,catyan,pantera
}
public class Enemy : MonoBehaviour
{
    public EnemyType enemyType;
    public float speed;

    public static Vector3[] roadPoints;
    public static float catyaSpeed;
    int contPoints=0;

    Vector3[] tofollow;


    private void Awake()
    {
        Transform tempT = GameObject.Find("Catyaroad").transform;
        roadPoints = new Vector3[tempT.childCount];
        Vector3 tempPoschild;
        for (int i = 0, j = 0; i < tempT.childCount; i++, j = j + Random.Range(2000,5000)) 
        {
            tempPoschild=tempT.GetChild(i).transform.localPosition;
            tempT.GetChild(i).transform.localPosition = new Vector3(tempPoschild.x, tempPoschild.y, j);
            roadPoints[i] = tempT.GetChild(i).transform.position;
        }
    }

    void Update()
    {
        //GetComponent<Rigidbody>().velocity = transform.forward * speed * 50;
        //CatyaConduct();
        switch (enemyType)
        {
            case EnemyType.catya:
                CatyaConduct();
                break;
        }
    }

    void CatyaConduct()
    {
        if (contPoints<roadPoints.Length-1)
        {
            if ((roadPoints[contPoints] - transform.position).magnitude < 10)
            {
                contPoints++;
            }
            transform.LookAt(roadPoints[contPoints]);
            GetComponent<Rigidbody>().velocity= transform.forward * speed;
        }
        else
        {
            Debug.Log("ya paró xd");
        }
    }

    void CatyanConduct()
    {
        
    }
}


        /*Transform tempT = GameObject.Find("Warapo").transform;

        childs = new GameObject[tempT.childCount];

        for (int i = 0; i < tempT.childCount; i++)
        {
            childs[i] = tempT.GetChild(i).gameObject;
        }*/
