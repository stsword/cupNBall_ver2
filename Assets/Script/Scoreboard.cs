using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;
public class Scoreboard : MonoBehaviour
{
    public TextMeshProUGUI score,highestScore;
    public static Scoreboard _instance;
    public static int totalScore = 0;
    scoreData readScore;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

    }

    void Start()
    {
        // read the highest score saved

        string saveFile = Application.dataPath + "/highScore.json";
        if (File.Exists(saveFile))
        {
             string fileContents = File.ReadAllText(saveFile);
            readScore = JsonUtility.FromJson<scoreData>(fileContents);
        }
        updateScore();
    }
   public void updateScore()
    {
      
        score.text = totalScore.ToString();
        highestScore.text = readScore.score.ToString();
    }
}