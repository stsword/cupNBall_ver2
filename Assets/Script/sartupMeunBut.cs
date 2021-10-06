using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sartupMeunBut : MonoBehaviour
{
    //play and quit appliction 
    public void playGame()

    {
        SceneManager.LoadScene("loadScene");
    }

    public void quit()
    {
        Application.Quit();

    }
}
