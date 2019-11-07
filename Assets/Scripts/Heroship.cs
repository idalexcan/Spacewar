﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Heroship : MonoBehaviour
{
    public GameObject cam, camOrigin, bullet, cannon, shotline, brujula, target;
    public GameObject[] bulletOrigin;

    public float speed, sensibility;
    public float mousex, mousey, mousexRange, camRemoteness;
    bool camUnestable;

    public int shotscount = 0;


    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        cam.transform.localScale=camOrigin.transform.localScale;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            speed = 50;
        }
        else
        {
            speed = 700;
        }

        Control();
        Shot();
        ClearProyectiles(30);

        if (Input.GetKey(KeyCode.E))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;

            if (transform.eulerAngles!=Vector3.zero)
            {
                transform.eulerAngles = Vector3.Lerp(new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z), Vector3.zero, sensibility / 50);

                GetComponent<Rigidbody>().freezeRotation = true;

            }

        }
    }


    float Abs(float n)
    {
        return Mathf.Sqrt(n*n);
    }
    
    void Control()
    {
        mousex = Input.GetAxis("Mouse X");
        mousey = Input.GetAxis("Mouse Y");

        mousexRange+=mousex;
        if (Abs(mousexRange)>12)
        { 
            camUnestable=true;
        }
        if (camUnestable)
        {
            cam.transform.localPosition=Vector3.Lerp(cam.transform.localPosition,Vector3.zero,sensibility/10);
            camRemoteness=(cam.transform.localPosition-Vector3.zero).magnitude;
            if (camRemoteness<1f)
            {
                camUnestable=false;
                mousexRange=0;
            }
        }else
        {
            cam.transform.localPosition+=new Vector3(mousex*-1,0,0)*sensibility/2;
        }

        if (Input.GetMouseButton(0))
        {
            GetComponent<Rigidbody>().velocity=transform.forward*speed;
        }
        else
        { 
            GetComponent<Rigidbody>().velocity=Vector3.zero;
        }
        transform.eulerAngles+=new Vector3(mousey,mousex*-1,0)*sensibility;
    }

    void Shot()
    {
        brujula.transform.LookAt(target.transform.position);
        shotline.SetActive(Input.GetKey(KeyCode.Space));
        if (Input.GetMouseButtonDown(1))
        {
            GameObject[] bullets = new GameObject[bulletOrigin.Length];
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i] = GameObject.Instantiate(bullet);
                bullets[i].transform.position = bulletOrigin[i].transform.position;
                bullets[i].transform.rotation = bulletOrigin[i].transform.rotation;
                bullets[i].GetComponent<Rigidbody>().AddForce(bulletOrigin[i].transform.up * 50000);
                bullets[i].AddComponent<Proyectile>();
                Debug.Log("cañofistola");
            }
            shotscount++;
        }
    }

    void ClearProyectiles(int limit)
    {
        if (shotscount > 30)
        {
            foreach (var item in GameObject.FindGameObjectsWithTag("proyectile"))
            {
                Destroy(item);
            }
            shotscount = 0;
        }
    }

}


