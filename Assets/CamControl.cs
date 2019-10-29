using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        Heroship.Move(gameObject,0.5f);
    }
}
