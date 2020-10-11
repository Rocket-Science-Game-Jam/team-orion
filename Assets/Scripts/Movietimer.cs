using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movietimer : MonoBehaviour
{
    public float timer = 16f;
    private float currenttime = 0f;
    

    // Update is called once per frame
    void Update()
    {
        if(currenttime<timer)
        {
            currenttime += Time.deltaTime;
            Debug.Log("time: " + currenttime);
        }
        else {
            Debug.Log("end");
        }

   
        
    }
}
