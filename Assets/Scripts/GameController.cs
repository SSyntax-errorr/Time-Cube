using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Pathfinding;

public class GameController : MonoBehaviour
{
    //[SerializeField]private GameObject objective;
    [SerializeField]private GameObject Clone;
    [SerializeField] private GameObject SpecialClone;
    [SerializeField] private GameObject SeekerClone;
    [SerializeField]private Player2 player;

    public static bool audioMuted;

    //[SerializeField]private Animator spawnObjective;
    

    [SerializeField]private List<GameObject> playerList;
    [SerializeField] private GameObject playerDefault;

    public string chosenPlayerTag;
    public GameObject chosenPlayer;
    public static bool objectiveReached = false;
    public static bool timerLimitReached = false;

    private int score;

    

    public static bool freeze;

    public static float lives;



    [SerializeField] private Text scoreText;
    [SerializeField] private Text liveText;
    [SerializeField] private Text highScoreText;
    public GameOverScreen gameOverScreen; 

    private int cloneChance, seekerChance;
    public int cloneInput;
  
    void Start()
    {
        cloneChance = cloneInput;
        //seekerChance = 30;
        lives = 3;
        score = 0;
        //MoveObjective();
        gameOverScreen.removeScreen();
        timerLimitReached = false;
        PlayerPrefs.GetInt("HighScore",0);
        Vector3 spawnPosition = new Vector3(0, 0, 102.5f);
        chosenPlayerTag = MainMenu.player;

        if(PlayerPrefs.GetInt("MuteState", 0) == 1){
            AudioListener.pause = true;
        }

        if(chosenPlayerTag != null){
            foreach (var player in playerList)
            {
                if(player.CompareTag(chosenPlayerTag)){
                    chosenPlayer = Instantiate(player,spawnPosition, Quaternion.identity);
                }
            }
        } else{
            chosenPlayer = Instantiate(playerDefault,spawnPosition, Quaternion.identity);
        }
        
       
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
                Debug.Log("Esc Pressed");
                if (isPaused) {
                    ResumeGame();
                    CloneMovement.pause = false;
                    InputRecorder.pause = false;
                } else if(!isPaused && lives > 0) {
                    CloneMovement.pause = true;
                    InputRecorder.pause = true;
                    PauseGame();
                }
        }
        //when player reaches yellow objective
        if(objectiveReached){
           score += 1;
           scoreText.text = "Score: " + score.ToString();
            objectiveReached = false;

            AIDestinationSetter.pause = false;
            Vector3 spawnPosition = new Vector3(0, 0, 102.5f); 
            Quaternion spawnRotation = Quaternion.identity;
            GameObject newClone;
            if(Random.Range(0, cloneChance) == 1){
                cloneChance *= 2;
                newClone = Instantiate(SpecialClone, spawnPosition, spawnRotation);
            } else if(Random.Range(0, 30) == 1){
                seekerChance *= 2;
                newClone = Instantiate(SeekerClone, spawnPosition, spawnRotation);
            } else{
                newClone = Instantiate(Clone, spawnPosition, spawnRotation);
            }
            
            
            
            Timer.RestartTimer();

            if (chosenPlayer.CompareTag("Player2"))
            {
                player = chosenPlayer.GetComponent<Player2>();
                player.addToList(newClone);
            }

           
            
           
        }

        liveText.text = "Lives: " + lives.ToString();

        //when player dies
        if(lives <= 0 || timerLimitReached == true){
            GameLoss();
            PlayerController.playerPause = true;
            CloneMovement.pause = true;
            
            Timer.timerPause = true;
            if(score > PlayerPrefs.GetInt("HighScore")){
                PlayerPrefs.SetInt("HighScore",score);
            }

            highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore",0).ToString();
        }
    }


   
   
   
   
    

    public void GameLoss(){
        gameOverScreen.displayScreen();
    }


    bool isPaused = false;


    [SerializeField] private GameObject pauseMenu;
    void PauseGame() {
        isPaused = true;
        Time.timeScale = 0;
        // Show the pause menu
        pauseMenu.SetActive(true);
    }

    void ResumeGame() {
        isPaused = false;
        Time.timeScale = 1; // Set it back to 1 for normal speed
        // Hide the pause menu
        pauseMenu.SetActive(false);
    }



}
