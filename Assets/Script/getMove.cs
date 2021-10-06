using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class getMove : MonoBehaviour
{
    
    public enum dir  {X,Y,Z}
    public bool tran, scale, rot, fade;
    public dir movDir=dir.X;
    public float timeLeft;
    public Vector3 startScale, endScale;
    TextMeshProUGUI objMat;
    public void active()
        
    {
        gameObject.SetActive(true);
        if (tran)
        {
            move();
        }
        if (rot)
        { }
        if (scale)
        {
            StartCoroutine(scaleStart());
        }
        objMat = gameObject.GetComponent<TextMeshProUGUI>();
        if (fade)
        {
            StartCoroutine(fadeStart());
        }
      
   
     

       
     
    }
    public void move()
    {
       
        switch (movDir)
        {
            case dir.X:
                StartCoroutine("StartCoMove", Vector3.right);
                break;
            case dir.Y:
                StartCoroutine("StartCoMove", Vector3.up); 
                break;
            case dir.Z:
                StartCoroutine("StartCoMove", Vector3.forward);
                break;
        }

    }

    IEnumerator StartCoMove(Vector3 inVect)
    {
        Vector3 holdPos = gameObject.transform.localPosition;
        var duration = timeLeft;
        while (duration > 0)
        {

            gameObject.transform.position += new Vector3(Time.fixedDeltaTime * inVect.x * 50, Time.fixedDeltaTime * inVect.y * 50, Time.fixedDeltaTime * inVect.z *50);
            duration -= .02f;
            yield return new WaitForSeconds(.02f);
        }
        
      
       gameObject.transform.localPosition = holdPos;
       
    }
    IEnumerator fadeStart()
    {
        var duration = timeLeft;
        while (duration > 0)
        {
            objMat.alpha = duration - .02f;
            duration -= .02f;
           
            yield return new WaitForSeconds(.02f);
        }
        gameObject.SetActive(false);
      
    }
    IEnumerator scaleStart()
    {
        var duration = timeLeft;
        while (duration > 0)
        {
            gameObject.transform.localScale = Vector3.Lerp(startScale, endScale, 1-(duration - .2f));
            duration -= .02f;
            
            yield return new WaitForSeconds(.02f);
        }
        
    }
}
