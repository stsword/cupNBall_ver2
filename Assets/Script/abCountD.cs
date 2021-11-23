using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
Load  botton image and reload the ability with time 
*/
public class abCountD : MonoBehaviour
{
    public float CD ;
    float tmpCD;
    Image cdImage;
    Button adButton;

   public void Start()
    {
        //Load the botton image

        tmpCD = CD;
        cdImage = gameObject.GetComponent<Image>();

        adButton = gameObject.GetComponent<Button>();
        adButton.interactable = false;
        print(cdImage + " " + adButton);
    }

   
    void Update()
    {
       // count down with deltaTime
       if (tmpCD >= 0)
        {
            tmpCD-= Time.deltaTime;
            cdImage.fillAmount = (CD - tmpCD) / CD;
          
        }

        else {
           adButton.interactable= true;
        }
    }
}
