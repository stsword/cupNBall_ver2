using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSFXonHit : MonoBehaviour
{
    
    public AudioClip _audioClip, _spawnClip ;

    public static playSFXonHit _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

    }

    void OnCollisionEnter()
    {
        AudioSource.PlayClipAtPoint(_audioClip,transform.position, 05f);
       
       
    }

    public void spawnS()

    {

        AudioSource.PlayClipAtPoint(_spawnClip, transform.position, 20f);

    }
}
