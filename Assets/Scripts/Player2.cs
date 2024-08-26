using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : PlayerController
{
    public List<GameObject> cloneList;

    private bool powerUsed = false;

    [SerializeField] private Animator p2Anim;
    [SerializeField] private AudioSource abilitySFX;

    [SerializeField] private GameObject powerCounterObj;
    [SerializeField] private Text powerCounterText;
    private int powerLeft;

    void Start()
    {
        powerLeft = 1;
        powerCounterObj = GameObject.FindGameObjectWithTag("powerText");
        powerCounterText = powerCounterObj.GetComponent<Text>();
        powerUsed = false;
        damageSFX = GetComponent<AudioSource>();
        
        playerCollider = GetComponent<Collider2D>();
    }
    public void addToList(GameObject clone){


        if(cloneList.Count > 4){
            cloneList.RemoveAt(0);
        }
        cloneList.Add(clone);
    }


    private void Update() {
        powerCounterText.text = string.Concat("Power left(Space bar): ", powerLeft);
        if(Input.GetKeyDown(KeyCode.Space) && powerLeft > 0){

            p2Anim.Play("p2ability");
            abilitySFX.Play();
            foreach (var clone in cloneList)
            {
                clone.SetActive(false);
            }
            powerLeft -= 1;
        }
    }
}
