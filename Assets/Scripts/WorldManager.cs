using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public GameObject endPoint, globalBrujula;
    
    void Update()
    {
        globalBrujula.transform.LookAt(endPoint.transform.position);
        EndPointConduct();
    }

    float timerA, timerlimitA, speed;
    int azardir;
    bool itsOutA;
    void EndPointConduct()
    {
        if ((endPoint.transform.localPosition-Vector3.zero).magnitude>2000)
        {
            itsOutA=true;
        }
        else if ((endPoint.transform.localPosition-Vector3.zero).magnitude<30)
        {
            itsOutA=false;
        }
        
       
        if (itsOutA)
        {
            endPoint.transform.localPosition=Vector3.Lerp(endPoint.transform.localPosition, Vector3.zero, speed/100);
        }
        else
        {
            timerA++;
            if (timerA>timerlimitA)
            {
                azardir=Random.Range(0,360);
                endPoint.transform.eulerAngles=new Vector3(0,0,azardir);
                timerA=0;
                speed=Random.Range(0, 30);
                timerlimitA=Random.Range(40,200);
            }
            endPoint.transform.position+=endPoint.transform.up*speed;
        }
    }
}
