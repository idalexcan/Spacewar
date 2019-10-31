using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroship : MonoBehaviour
{
    public GameObject ship, bullet, cannon;
    public GameObject[] bulletzero;

    public float speed=3;
    public float xrot, yrot;
    public float timerclick;

    public int shotscount=0;

    void Awake()
    {
        Cursor.visible=false;
        Cursor.lockState=CursorLockMode.Locked;

        //ship=transform.GetChild(0).gameObject;
        //cannon=transform.GetChild(0).transform.GetChild(1).gameObject;
        //bulletzero=GameObject.FindGameObjectsWithTag("mycanon");
        
        cannon= transform.GetChild(1).gameObject;
        bulletzero = GameObject.FindGameObjectsWithTag("mycanon");
    }
    void Update()
    {
        Control(); 
        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }  
    }

    void Control()
    {
        xrot = Input.GetAxis("Mouse X");
        yrot = Input.GetAxis("Mouse Y");
        if (Input.GetMouseButton(0))
        {
            float speedaux;
            timerclick++;
            if (Input.GetMouseButton(0)&&timerclick<5)
            {
                speedaux = speed * 2;
                timerclick = 0;
            }
            else
            {
                speedaux = speed;
            }
            transform.position += transform.forward * speedaux;
        }

    }

    /*void Control()
    {
        xrot=Input.GetAxis("Mouse X");
        yrot=Input.GetAxis("Mouse Y");
        float xcannon = ship.transform.eulerAngles.x, zcannon = ship.transform.eulerAngles.z;
        cannon.transform.localEulerAngles+=new Vector3(0,xrot,0);
        transform.eulerAngles+=new Vector3(yrot*-1,0,0);

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
            ship.transform.Rotate(transform.up*speed*0.3f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            ship.transform.Rotate(transform.up*(-1)*speed*0.3f);    
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


