using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
   public void displayScreen(){
        gameObject.SetActive(true);
   }

   public void removeScreen(){
        gameObject.SetActive(false);
   }

   public void Restart(){
        SceneManager.LoadScene("Game");
   }

   public void ReturnToMenu(){
          SceneManager.LoadScene("Main Menu");
   }
}
