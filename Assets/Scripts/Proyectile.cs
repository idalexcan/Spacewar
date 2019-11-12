using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeProyectile
{
    bullet, catyanStone
}
public class Proyectile : MonoBehaviour
{
    public TypeProyectile type;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case TypeProyectile.catyanStone:
            CatyanStoneControl();
            break; 
         
        }
    }

    int timer=0;
    void CatyanStoneControl()
    {
        timer++;
        if (timer>13)
        {
            if (transform.localScale.magnitude<60)
            {
                transform.localScale+=new Vector3(1,1,1)*0.7f;
            }
            else
            {
                GetComponent<SphereCollider>().enabled=true;
            }
            
            if (timer>150)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            other.GetComponent<Enemy>().dead=true;
            other.GetComponent<Enemy>().ImDead(); 
        }        
    }
}
