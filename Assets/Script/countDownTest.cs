using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;


public class countDownTest : MonoBehaviour
{
    //total value of the enegry bar
    public int _CDT;
    
    public static float countdownTime;
    public Slider progBarSlider;
    public Text timerText;
    public TextMeshProUGUI levelText;
    public getMove gameOverObj;
    public int Level=0;
    public static float min, sec,holdTime;
    public getMove levelVfx;
    scoreData highestScore;
    RectTransform fillRect;
    public GameObject alertSFX;
    Image fillImage;
     void Start()
    {
        //load the energry count down bar
        fillRect = progBarSlider.GetComponent<Slider>().fillRect;
        fillImage = fillRect.GetComponent<Image>();
        //intialize the current time when game start
        holdTime = 0;
         //intialize the total value of the energy bar
        countdownTime = _CDT;
        //Load highest score
        string saveFile = Application.dataPath + "/highScore.json";
        if (File.Exists(saveFile))
        {
            
        string fileContents = File.ReadAllText(saveFile);
        highestScore = JsonUtility.FromJson<scoreData>(fileContents);
           
        }

        StartCoroutine(leveltimer());

        StartCoroutine(CountdownToStart());

        StartCoroutine(timer());

    }

    // coroutine to show current time of plying
    IEnumerator timer()
    {

        while (true)
        {
            holdTime += Time.deltaTime;
            min = Mathf.FloorToInt(holdTime / 60);
            Level= (int)(min) ;
            sec = Mathf.FloorToInt(holdTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", min, sec);
            yield return null;
        }

        
       
    }

    // coroutine control level up when time goes
    IEnumerator leveltimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(60);
            setLevelDis();
        }

     
    }
    // control the display of level up
    public void setLevelDis()
    {
        var tmpTex = levelVfx.GetComponent<TextMeshProUGUI>();
       tmpTex.text = ("LEVEL " + Level.ToString());
        
        levelVfx.active();
        levelText.text =("LEVEL "+ Level.ToString());


    }
    //corountine control the countdown of the energy bar
    IEnumerator CountdownToStart()
    {
        //  the blinking of energy bar while its lower than 30%
       
        while (countdownTime > 0)
        {
            if (countdownTime < 30)
            {
                fillImage.color = new Color(fillImage.color.r, fillImage.color.g, fillImage.color.b, Mathf.Abs(Mathf.Sin(Time.time * 100)) * .8f + .2f);
                alertSFX.SetActive(true);

            }
            else
            {
                alertSFX.SetActive(false);
                fillImage.color= new Color(fillImage.color.r, fillImage.color.g, fillImage.color.b, 1f);
            }
            yield return new WaitForSeconds(.1f);
            countdownTime= countdownTime-.1f*(Level+1);
           // print(countdownTime);
            progBarSlider.value = countdownTime * .01f;
           
        }
        // write the final score into a .json if it is the highest score
#if (UNITY_EDITOR)
     if (Scoreboard.totalScore > highestScore.score)
        {
          saveScore tmp = new saveScore();
          saveScore._scoreDate.score = Scoreboard.totalScore;
           tmp.save();

        }
#endif
     //gameover stage
        cupCreation._instance.panelCtrl.SetActive(false);
        Scoreboard.totalScore = 0;
        yield return new WaitForSeconds(1f);
        failStage();
      
    }
  //back to the startup page
    void failStage()
    {
        gameOverObj.active();
        Invoke("reLoad", 2);
    }
    void reLoad()
    {

        SceneManager.LoadScene("startPage");
    }

}