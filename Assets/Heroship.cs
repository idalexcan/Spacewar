using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroship : MonoBehaviour
{
    public GameObject ship, bullet, cannon;
    public GameObject[] bulletzero;
    public static float speed=7;
    public static float xrot, yrot, xlimit, ylimit;
    public int shotscount=0;
    void Awake()
    {
        Cursor.visible=false;
        Cursor.lockState=CursorLockMode.Locked;

        ship=transform.GetChild(0).gameObject;
        cannon=transform.GetChild(0).transform.GetChild(1).gameObject;
        bulletzero=GameObject.FindGameObjectsWithTag("mycanon");
        
        
    }
    void Update()
    {
        Control(); 
        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }  
    }
    //float rotfx=2;
    void Control()
    {
        xrot=Input.GetAxis("Mouse X");
        yrot=Input.GetAxis("Mouse Y");
        cannon.transform.eulerAngles+=new Vector3(0,xrot,0);//yrot*-1
        transform.eulerAngles+=new Vector3(yrot*-1,0,0);//
        if (Input.GetKey(KeyCode.W))
        {
            transform.position+=ship.transform.forward*speed;
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position-=ship.transform.forward*speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            ship.transform.Rotate(transform.up*speed*0.7f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            ship.transform.Rotate(transform.up*(-1)*speed*0.7f);    
        }
        //transform.eulerAngles=new Vector3(transform.eulerAngles.x, ship.transform.eulerAngles.y, transform.eulerAngles.z);
        
        //cursor.transform.position+=new Vector3(xrot,0,0);
        //cannon.transform.LookAt(cursor.transform.position);
    }

    /*void Control()
    {
        xrot=Input.GetAxis("Mouse X");
        yrot=Input.GetAxis("Mouse Y");
        transform.eulerAngles+=new Vector3(yrot*-1,xrot,0);
        cursor.transform.position+=new Vector3(xrot,0,0);
        cannon.transform.LookAt(cursor.transform.position);
        if(Input.GetKey(KeyCode.W))
        {
            transform.position+=transform.forward*speed;
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position-=transform.forward*speed;
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.position+=transform.right*speed;
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.position-=transform.right*speed;
        } 
        if(Input.GetKey(KeyCode.Space))
        {
            transform.position+=transform.up;
        }     

    }*/

    void Shot()
    {
        GameObject[] bullets=new GameObject[bulletzero.Length];
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i]=GameObject.Instantiate(bullet);
            bullets[i].transform.position=bulletzero[i].transform.position;
            bullets[i].transform.rotation=bulletzero[i].transform.rotation;
            bullets[i].GetComponent<Rigidbody>().AddForce(bulletzero[i].transform.up*20000);
        }
        shotscount++;
        if (shotscount>30)
        {
            foreach (var item in GameObject.FindGameObjectsWithTag("proyectile"))
            {
                Destroy(item);
            }
            shotscount=0;
        }
        Debug.Log(shotscount);
    }
}


