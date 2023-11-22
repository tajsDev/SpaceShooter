using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Counter : MonoBehaviour
{
    TMP_Text score;
   public bool enemies = false;
    int counter;
    public void Start()
    {
        score = GetComponent<TMP_Text>();

    }

    public void Update()
    {
        
        if(enemies)
        {
            counter = ScoreTracker.NUM_ENEMIES;

        }
        else
        {
            counter = ScoreTracker.score;
        }
        score.SetText($"{counter}");
    }
}
