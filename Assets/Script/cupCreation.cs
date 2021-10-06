using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using UnityEngine.SceneManagement;


public class cupCreation : MonoBehaviour


{
    [SerializeField] float forceMulti = 2500f;
    [SerializeField] float gravity = -20f;
    public ParticleSystem spawnPart;
    public static cupCreation _instance;
    public GameObject cup;
    public TrailRenderer trail;
    public Collider targetCollider;
    public Text posLog,mousePos;
    public GameObject ball, ballShape,pointerGrp,panelCtrl;
   
    Rigidbody ballRig;
    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

    }
    void Start()
    {
        //Debug.Log(Application.persistentDataPath);
        float randScale,finalPosX;
        ballRig = ball.GetComponent<Rigidbody>();
        spawn();
        randScale = Random.Range(0.3f, 0.5f);
        finalPosX = Random.Range(((6 - (randScale * 10)) *- 0.5f), ((6 - (randScale * 10))*0.5f));
        cup.SetActive (true);
        cup.transform.localScale=Vector3.one* randScale;
        cup.transform.position=new Vector3(finalPosX,0, 0);
        //Debug.Log(cup.transform.localScale);
        Physics.gravity = new Vector3(0, -20, 0);



    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 screenPos = Input.mousePosition;




        if (Input.GetMouseButton(0))
        {
            setPointerPos();
        }

    }
    /*
    method to spawn a new cup after the ball get in
     */
    public void cupReNew()
    {

        float randScale, finalPosX;
        randScale = Random.Range(0.25f, 0.30f);
        finalPosX = Random.Range(((6 - (randScale * 10)) * -0.5f), ((6 - (randScale * 10)) * 0.5f));
        //cup.SetActive(true);
        cup.transform.localScale = Vector3.one * randScale;
        cup.transform.position = new Vector3(finalPosX, 0, 0);
    }

    /*
    method to spawn a new ball
     */

    public void spawn()
    {

        trail.enabled = false;
        var locL = new Vector3(Random.Range(-5f, -3.5f), Random.Range(1.5f, 6f), 0);
        var locR = new Vector3(Random.Range(3.5f, 6.5f), Random.Range(1.5f, 6f), 0);
        if (Random.Range(-1, 1) >= 0)
            ball.transform.position = locL;
        else
            ball.transform.position = locR;
        StartCoroutine(sizeControl());
       playPart();
    }



    /*
   reset the scenes after gameover
    */

    public void Reset()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    //set the charge arrow to the center of the ball
    public void setPointerPos()
    
    {
       
        pointerGrp.transform.position = ball.transform.position;


    }
    // give a force to ball when release
    public void applyFinalForce()
    {
        Vector3 newVector=ball.transform.position + touchctrl.XYinput;
        Vector3 finalVector = -newVector + ball.transform.position;
        ballRig.AddForce(finalVector * forceMulti);
    }

    //play the VFX of ball spawn
    public void playPart()
    {
        spawnPart.Play();
    }

    //scaling up when the ball spawn 
    IEnumerator sizeControl()
    {
        float count = 1f;
        while (count > 0)
        {

            ballShape.transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(.5f,.5f,.5f), (1f-count));
            yield return new WaitForEndOfFrame();
            count = count - Time.deltaTime;
        }

        trail.enabled = true;
        yield return null;
    }
}
