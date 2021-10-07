using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//method to control the input handle 
public class touchctrl : MonoBehaviour
{
    public static Vector3 XYinput;
   // public delegate void TouchStateDelegate(bool touchPresent);
   // bool touchPre;
    Quaternion rot;


    [SerializeField]
    GameObject indic, handle,dum;
    bool checkTouch=true;
    //calculate the vector when handle being drag
   
    public void dragCallback(Vector2 inVal)
    {
            Vector3 indicScale = indic.transform.localScale;
            XYinput = new Vector3((inVal.x * -1f + .5f) * 2f, (inVal.y * -1f + .5f) * 2f, 0);
            rot = Quaternion.FromToRotation(Vector3.up, XYinput);
            indic.transform.rotation = rot;
            indic.transform.localScale = new Vector3(indicScale.x, Mathf.Abs(XYinput.magnitude) * 2.3f + .3f, indicScale.z);
       
      
    }
    //recoil of the handle 
    public void backToOrg()
    {
        dum.SetActive(true);
        handle.transform.localPosition = Vector3.zero;
        this.gameObject.SetActive(false);
    }

}


