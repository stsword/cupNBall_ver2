using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class abilityCenter : MonoBehaviour
{
    public GameObject ball;
   
    public void InertBoost()
    {

        Rigidbody rg = ball.GetComponent<Rigidbody>();
        rg.AddForce(rg.velocity.normalized* 500);
    }
    public void reversBoost()
    {

        Rigidbody rg = ball.GetComponent<Rigidbody>();
        rg.AddForce(-rg.velocity.normalized * 500);
    }
   
    
}
