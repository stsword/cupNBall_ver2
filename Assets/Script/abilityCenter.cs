using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class abilityCenter : MonoBehaviour
{
    public GameObject ball;
   
    public void leftBoost()
    {

        Rigidbody rg = ball.GetComponent<Rigidbody>();
        rg.velocity = new Vector3(-10, 0, 0);
        //rg.AddForce(new Vector3(-5000, 0, 0));
    }
    public void rightBoost()
    {

        Rigidbody rg = ball.GetComponent<Rigidbody>();
        rg.velocity = new Vector3(10, 0, 0);
       // rg.AddForce(new Vector3 (5000,0,0));
    }
   
    
}
