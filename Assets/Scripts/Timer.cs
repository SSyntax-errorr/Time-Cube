using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    
    [SerializeField]Text timer;
    public static float remainingTime;
    public float timerAdd;

    public static bool timerPause;
    void Start()
    {
        timerPause = false;
        remainingTime = 16;
    }
    
    void Update()
    {
        if(timerPause){
            return;
        }

        if(remainingTime > 0){
            remainingTime -= Time.deltaTime;
        } else if(remainingTime < 1){
            remainingTime = 0;
            GameController.timerLimitReached = true;
        }
        
        int minutes = Mathf.FloorToInt(remainingTime/60);
        int seconds = Mathf.FloorToInt(remainingTime%60);
        timer.text = string.Format("{00:00}:{01:00}", minutes, seconds);
    }

    public static void RestartTimer(){
        remainingTime = 16;
    }
}
