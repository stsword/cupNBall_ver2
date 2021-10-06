using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFlick : MonoBehaviour
{
    public float baseIntensity, flickAmp,freq;
    Light _light;
   //control the flicking of the main light
     void Start()
    {
        _light = gameObject.GetComponent<Light>();
        StartCoroutine(lightFlicker());
    }
     IEnumerator lightFlicker()
    {
        while (true)
        {
            _light.intensity = baseIntensity + Random.Range(-flickAmp * .5f, flickAmp * .5f);
            yield return new WaitForSeconds(freq);
        }
    }
}
