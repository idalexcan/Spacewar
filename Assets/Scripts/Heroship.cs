using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Heroship : MonoBehaviour
{
    public GameObject cam, camOrigin, bullet, cannon, shotline, brujula, target, globalBrujula;
    public GameObject[] bulletOrigin;

    public float speed, sensibility;
    public float mousex, mousey, camDistance;
    public int shotscount = 0;
    public bool colapse;


    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        cam.transform.position=camOrigin.transform.position;
    }

    void Update()
    {
        if (colapse==false)
        {
            Control();
            Shot();
            ClearProyectiles(30);
        }
        

        /*if (Input.GetKey(KeyCode.E))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;

            if (transform.eulerAngles!=Vector3.zero)
            {
                transform.eulerAngles =
                 Vector3.Lerp(
                    new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z), 
                    globalBrujula.transform.eulerAngles, 
                    sensibility / 50);
                GetComponent<Rigidbody>().freezeRotation = true;

            }

        }*/

    }

    private void OnCollisionEnter(Collision collision)
    {
        colapse = true;
    }

    float speedaux;
    void Control()
    {
        mousex = Input.GetAxis("Mouse X");
        mousey = Input.GetAxis("Mouse Y");
        
        camDistance=(cam.transform.position-camOrigin.transform.position).magnitude;
        if (camDistance>10)
        {
            cam.transform.position=camOrigin.transform.position;
        }

        // Movimiento y rotación de nave 
        if (Input.GetKey(KeyCode.Space))
        {
            speedaux=speed*2f;
        }
        else
        {
            speedaux=speed;
        }
        if (Input.GetMouseButton(0))
        {
            GetComponent<Rigidbody>().velocity=transform.forward*speedaux;
            cam.GetComponent<Rigidbody>().velocity=transform.forward*speedaux;
        }
        else
        { 
            GetComponent<Rigidbody>().velocity=Vector3.zero;
            cam.GetComponent<Rigidbody>().velocity=Vector3.zero;
        }
        transform.Rotate(new Vector3(mousey,mousex*-1,0)*sensibility);
        cam.transform.Rotate(new Vector3(mousey,mousex*-1,0)*sensibility);
    }

    void Shot()
    {
        brujula.transform.LookAt(target.transform.position);
        //shotline.SetActive(Input.GetKey(KeyCode.Space));
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


