using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//  writing a .json 
public class saveScore : MonoBehaviour
{
     public static scoreData _scoreDate = new scoreData();

    public void save()

    {
        string scoreIn = JsonUtility.ToJson(_scoreDate);
        System.IO.File.WriteAllText(Application.dataPath + "/highScore.json", scoreIn);
        print("save");
    }
}
[System.Serializable]
public class scoreData
{
    public int score;

}
[System.Serializable]
public class setting
{
    public int bgmVol;
    public int sfxVol;
}
