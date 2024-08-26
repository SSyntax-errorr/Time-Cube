using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneMovement : MonoBehaviour
{
    protected List<Vector2> recordedMovements;
    protected List<Vector3> recordedPositions;
    protected int currentIndex = 0;
    protected GameObject sfx;



    public float replaySpeed = 1.0f;

    protected float delay = 4f;
    protected float delayTimer = 0f;

    public static bool pause = false;

    protected Collider2D cloneCollider;

    protected float disappearTimer;

    protected virtual void Start()
    {
        pause = false;
        recordedMovements = FindObjectOfType<InputRecorder>().recordedMovements;
        recordedPositions = FindObjectOfType<InputRecorder>().recordedPositions;
        sfx = GameObject.FindGameObjectWithTag("sfx");
         
        ColliderSetup();
        disappearTimer = 10;
        
    }

    protected virtual void ColliderSetup(){
        cloneCollider = GetComponent<Collider2D>();
    }

    protected void Update()
    {
        if (pause == true){
            //Debug.Log(pause);
            return;
        } else if(delayTimer < delay){
            delayTimer += Time.deltaTime;
            return;
        } else {
            SpawnClones();
        }

        disappearTimer -= Time.deltaTime;
         if(disappearTimer <= 4){
            DisappearAnim();
        }

        if(disappearTimer <= 0){
            Disappear();
        }

        if(PlayerController.colliderCooldown == true){
            cloneCollider.enabled = false;
        } else{
            cloneCollider.enabled = true;
        }

       
    }
    protected virtual void DisappearAnim(){

    }
    protected virtual void Disappear(){

    }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log(LayerMask.LayrToName(other.gameObject.layer));
        if(other.transform.gameObject.layer == 7 && PlayerController.colliderCooldown == false){ //7 is the player layer
            GameController.lives -= 1;
            //hit.SetTrigger("Hit");
            gameObject.SetActive(false);
            //this.SetActive(false);
            //objectiveSpawnSFX.Play();

        } 
    }

    public void SpawnClones(){
        if (currentIndex < recordedMovements.Count)
        {
            Vector2 movement = recordedMovements[currentIndex];
            Vector3 position = recordedPositions[currentIndex];

            
            transform.Translate(movement * replaySpeed * Time.deltaTime);
            transform.position = position;

            currentIndex++;
        }
    }


}