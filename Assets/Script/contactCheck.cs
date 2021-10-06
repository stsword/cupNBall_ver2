using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contactCheck : MonoBehaviour
{

    public GameObject spark;
    GameObject oldPart;
   void OnCollisionEnter(Collision inCol)

    {
        if (oldPart != null)

        {
            Destroy(oldPart);
        }
      oldPart= Instantiate(spark,inCol.contacts[0].point, Quaternion.identity);
        //  print(inCol.contacts[0].point);
    }
}
