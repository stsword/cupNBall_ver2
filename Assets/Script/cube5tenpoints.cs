using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube5tenpoints : MonoBehaviour
{
    public getMove secBuons;
    public int bounsT;
    public GameObject secUp;
    /*a chain of actions after the ball hit the bottom of cup
    update total score, add bouns time, spawn the cup nad ball, play hit sfx,
       */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Ball")
        {

            secBuons.active();
            Debug.Log("Hit the bottom of cup");
            Scoreboard.totalScore += 10;
            countDownTest.countdownTime+=bounsT;
            cupCreation._instance.spawn();
            playSFXonHit._instance.spawnS();
            cupCreation._instance.cupReNew();
            Scoreboard._instance.updateScore();
            cupCreation._instance.trail.enabled = false;
          
            
        }
       
    }
}