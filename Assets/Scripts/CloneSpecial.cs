using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSpecial : CloneMovement
{
    private int disappear;
    public Animator disappearAnim;
    protected override void DisappearAnim(){
        disappearAnim.Play("seekerDisappear");
    }
    protected override void Disappear(){
        gameObject.SetActive(false);
    }
 
    protected override void OnCollisionEnter2D(Collision2D other)
    {
        

        if(other.transform.gameObject.layer == 7){ //7 is the player layer

            gameObject.SetActive(false);
            GameObject[] clones = GameObject.FindGameObjectsWithTag("Past");
            GameObject[] clonesSpecial = GameObject.FindGameObjectsWithTag("Special Clone");
            GameObject[] seekerClones = GameObject.FindGameObjectsWithTag("Seeker Clone");


            foreach (GameObject clone in clones)
            {
                clone.SetActive(false);
            }

            foreach (GameObject clone in clonesSpecial)
            {
                clone.SetActive(false);
            }

            foreach (GameObject clone in seekerClones)
            {
                clone.SetActive(false);
            }

        } 
    }

}
