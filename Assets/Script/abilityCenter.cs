using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 Class which handle all abilities, more ability can be added
 */
public class abilityCenter : MonoBehaviour
{
    public GameObject ball;
   //ability boost the ball move to left
    public void leftBoost()
    {

        Rigidbody rg = ball.GetComponent<Rigidbody>();
        rg.velocity = new Vector3(-10, 0, 0);
        //rg.AddForce(new Vector3(-5000, 0, 0));
    }
    //ability boost the ball move to right
    public void rightBoost()
    {

        Rigidbody rg = ball.GetComponent<Rigidbody>();
        rg.velocity = new Vector3(10, 0, 0);
       // rg.AddForce(new Vector3 (5000,0,0));
    }
   
    
}
