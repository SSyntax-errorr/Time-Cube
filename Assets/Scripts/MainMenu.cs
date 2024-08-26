using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    [SerializeField]private Text highScoreText;

    public static string player;

    [SerializeField]private AudioSource sfx;

    [SerializeField] private  Button defaultPlayer;

    private string sceneName = "Game";

    [SerializeField] private Button player2btn;
    [SerializeField] private Button player3btn;

    
    
    void Start()
    {
        //PlayerPrefs.SetInt("HighScore",0);
        player = "Player1";
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore",0).ToString();
        //AudioListener.pause = false;
        defaultPlayer.Select();
        if(PlayerPrefs.GetInt("HighScore",0) < 20){
            player2btn.interactable = false;
        }

        if(PlayerPrefs.GetInt("HighScore",0) < 30){
            player3btn.interactable = false;
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void PlayerSelector(string playerTag){
        player = playerTag;
    }

    public void ClickSfx(){
        sfx.Play();
    }

     public void EnableOrDisableSound()
    {
        AudioListener.pause = !AudioListener.pause;
        GameController.audioMuted = AudioListener.pause;
        
    }



  

    
}
