using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    a group of actions after the ball hit the bottom of cup
   update total score, add bouns time, spawn the cup nad ball, play hit sfx,
      */
public class cube5tenpoints : MonoBehaviour
{
    public getMove secBuons;
    public int bounsT;
    public GameObject secUp;
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Ball")
        {

            secBuons.active();
            Debug.Log("Hit the bottom of cup");
            Scoreboard.totalScore += 10;
            
            //add bouns time when the ball enter the cup
            countDownTest.countdownTime+=bounsT;
            
            //generate new ball after scored
            cupCreation._instance.spawn();
           
            //generate new cup after scored
            cupCreation._instance.cupReNew();
            
            //disable the trail of the ball when spawn
            cupCreation._instance.trail.enabled = false;
            
            //Add scored when goal
            Scoreboard._instance.updateScore();
            playSFXonHit._instance.spawnS();


        }
       
    }
}