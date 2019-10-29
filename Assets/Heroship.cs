using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroship : MonoBehaviour
{
    GameObject ship;
    GameObject cam;
    public static float speed=1;
    void Awake()
    {
        ship=transform.GetChild(0).gameObject;
        cam=transform.GetChild(1).gameObject;
    }
    void Start()
    {
        
    }

    public static float xrot, yrot;
    //Vector3 rot;
    void Update()
    {
        Move(gameObject,1);
    }

    public static void Move(GameObject go, float sensibility)
    {
        xrot=Input.GetAxis("Mouse X");
        yrot=Input.GetAxis("Mouse Y");
        go.transform.eulerAngles+=new Vector3(yrot,xrot,0)*sensibility;
        go.transform.position+=new Vector3();
        if(Input.GetKey(KeyCode.W))
        {
            go.transform.position+=go.transform.forward*speed;
        }
        if(Input.GetKey(KeyCode.S))
        {
            go.transform.position-=go.transform.forward*speed;
        }
        if(Input.GetKey(KeyCode.D))
        {
            go.transform.position+=go.transform.right*speed;
        }
        if(Input.GetKey(KeyCode.A))
        {
            go.transform.position-=go.transform.right*speed;
        }
    }
    
}
