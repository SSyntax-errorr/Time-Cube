using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;


public class Player3 : PlayerController
{
    float powerCooldown;
    bool startCooldown;
    bool powerUsed;
    [SerializeField] private Animator p3Anim;
    [SerializeField] private AudioSource abilitySFX;

    [SerializeField] private GameObject powerCounterObj;
    [SerializeField] private Text powerCounterText;

    private int powerLeft;
    void Start()
    {
        powerCounterObj = GameObject.FindGameObjectWithTag("powerText");
        powerCounterText = powerCounterObj.GetComponent<Text>();
        powerCooldown = 5f;
        powerUsed = false;
        damageSFX = GetComponent<AudioSource>();
        playerCollider = GetComponent<Collider2D>();
        
        powerLeft = 3;
    }

    // Update is called once per frame
    void Update()
    {
        powerCounterText.text = string.Concat("Power left(Space bar): ", powerLeft);

        if(Input.GetKeyDown(KeyCode.Space) && powerLeft > 0){
            p3Anim.Play("p3ability");
            abilitySFX.Play();
            FreezeClones();
            powerLeft -= 1;
            
        }

        if(startCooldown){
            powerCooldown -= Time.deltaTime;
            if(powerCooldown <= 0){
                powerCooldown = 5f;
                
                UnFreezeClones();
                startCooldown = false;
            }
        }

    }

    void FreezeClones(){
        CloneMovement.pause = true;
        AIDestinationSetter.pause = true;
        startCooldown = true;
    }

    void UnFreezeClones(){
        CloneMovement.pause = false;
        AIDestinationSetter.pause = false;
    }
}
