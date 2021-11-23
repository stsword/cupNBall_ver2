using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//class control SFX play
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
    // play sfx when collide
    void OnCollisionEnter()
    {
        AudioSource.PlayClipAtPoint(_audioClip,transform.position, 05f);
    }

    //play sfx when new ball spawn

    public void spawnS()

    {

        AudioSource.PlayClipAtPoint(_spawnClip, transform.position, 20f);

    }
}
