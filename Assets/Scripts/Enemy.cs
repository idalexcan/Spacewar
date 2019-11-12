using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    catya,catyan,pantera
}
public class Enemy : MonoBehaviour
{
    // Variables generales
    public EnemyType enemyType;
    public bool dead;
    public float speed;
    public int life;
    
    
    

    void Awake()
    {
        
    }
    
    // void Start()
    // {
    //     for (int i = 0; i < 400; i++)
    //     {
    //         GameObject cubo=GameObject.Instantiate(GameObject.Find("Cubito"));
    //         float x=Random.Range(-300,300), y=Random.Range(-300,300), z=Random.Range(-200,10000);
    //         cubo.transform.position=new Vector3(x,y,z);
    //     }
    // }

    
    void Update()
    {
        
    }

    public void ImDead() // CUANDO EL ENEMIGO MUERE
    {
        Interface.EnemyDead(gameObject, enemyType);
        gameObject.SetActive(false);
    }

    
}
 



