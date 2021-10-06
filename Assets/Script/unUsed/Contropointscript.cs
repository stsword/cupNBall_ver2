using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contropointscript : MonoBehaviour
{
    float xroat, yroat = 0f;
    float forwardX, forwardY, forwardZ;
    public Rigidbody ball;
    Vector3 reCalF;
    public float rotatespeed = 5f;
    public LineRenderer Line;
    public float shootpower = 30f;
   
    void Update()
    {
        transform.position = ball.position;
        if (Input.GetMouseButton(0))
        {
            xroat += Input.GetAxis("Mouse X") * rotatespeed;
            yroat += Input.GetAxis("Mouse Y") * rotatespeed;
            transform.rotation = Quaternion.Euler(yroat, xroat, 0f);
            forwardX = transform.forward.x;
            forwardY = transform.forward.y;
            forwardZ = transform.forward.z;
            reCalF =new Vector3( -forwardX,forwardY,forwardZ);
            Line.gameObject.SetActive(true);
            Line.SetPosition(0, transform.position);
            //print(transform.forward);
            Line.SetPosition(1, transform.position + reCalF * 4f);
            if (yroat < -35f)
            {
                yroat = -35f;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            ball.velocity = transform.forward * shootpower;
            Line.gameObject.SetActive(false);
        }
    }
}
