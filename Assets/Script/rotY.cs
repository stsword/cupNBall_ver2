using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// control the self-rotation of the ball(no physic related)

public class rotY : MonoBehaviour
{
    public int dir =0 ;
    public int speed= 50;

 void Update()
    {
        if (dir ==0)
        transform.Rotate(Vector3.back * Time.deltaTime*speed);
        else
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);
    }

}