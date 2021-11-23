using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 
 check if the ball hit the ground and emit spark if yes 
*/

public class contactCheck : MonoBehaviour
{

    public GameObject spark,controlPan, controlPanDum;
    GameObject oldPart;
   
     void Start()
    {
      
    }
    void OnCollisionEnter(Collision inCol)

    {
        //disable the joystick when the ball is in air
        if (inCol.gameObject.tag =="floor")
        {
            controlPan.SetActive(true);
            controlPanDum.SetActive(false);
        }
        if (oldPart != null)

        {
            Destroy(oldPart);
        }

        //emit spark at the hit point

        oldPart = Instantiate(spark,inCol.contacts[0].point, Quaternion.identity);
        
        //  print(inCol.contacts[0].point);
    }
}
