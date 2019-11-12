using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    public static bool catyaDead;
    public GameObject whenCatyaDead;


    void Start()
    {
        
    }

    void Update()
    {
        whenCatyaDead.SetActive(catyaDead);
    }

    public static void EnemyDead(GameObject enemy, EnemyType type)
    {
        switch (type)
        {
            case EnemyType.catya:
                catyaDead=true;
                break;
        }
    }
}
