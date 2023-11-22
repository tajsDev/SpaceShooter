using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void Restart()
    {
        ScoreTracker.score = 0 ;
        SceneManager.LoadScene("TitleCard");
    }

    // Update is called once per frame
    public void EasyMode()
    {
        ScoreTracker.NUM_ENEMIES = 30;
        SceneManager.LoadScene("__Scene_0");
    }

    // Update is called once per frame
    public void MediumMode()
    {
        ScoreTracker.NUM_ENEMIES = 45;
        SceneManager.LoadScene("__Scene_1");
    }

    // Update is called once per frame
    public void HardMode()
    {
        ScoreTracker.NUM_ENEMIES = 60;
        SceneManager.LoadScene("__Scene_2");
    }
    // Update is called once per frame
    public void UltraMode()
    {
        ScoreTracker.NUM_ENEMIES = 75;
        SceneManager.LoadScene("__Scene_3");
    }
}
