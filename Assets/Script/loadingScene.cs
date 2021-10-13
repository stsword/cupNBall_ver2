using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadingScene : MonoBehaviour
{
    public Image progessBar;



    void Start()
    {
        StartCoroutine(loadPro());
    }

    IEnumerator loadPro()
    {
        AsyncOperation checkPro = SceneManager.LoadSceneAsync("gamePlay_2");

        while (checkPro.progress < 1)
            {
            progessBar.fillAmount = checkPro.progress;
            print(checkPro.progress);
            yield return new WaitForSeconds(.1f);
            
        }

        yield return new WaitForEndOfFrame();


    }
}
