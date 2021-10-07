using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contactCheck : MonoBehaviour
{

    public GameObject spark,controlPan, controlPanDum;
    GameObject oldPart;
   
     void Start()
    {
      
    }
    void OnCollisionEnter(Collision inCol)

    {
        if (inCol.gameObject.tag =="floor")
        {
            controlPan.SetActive(true);
            controlPanDum.SetActive(false);
                }
        if (oldPart != null)

        {
            Destroy(oldPart);
        }
      oldPart= Instantiate(spark,inCol.contacts[0].point, Quaternion.identity);
        //  print(inCol.contacts[0].point);
    }
}
