using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EvilClone : MonoBehaviour
{
    //public GameObject objectToDisable;
    public float delayInSeconds = 10f;
    public float disappearAnimationTimer;
    public Animator disappearAnim;

    public static bool pause;

    //[SerializeField] private Rigidbody2D rb;

    public bool anim;
    private void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        disappearAnimationTimer = delayInSeconds;
        anim = false;
        StartCoroutine(DisableAfterDelay());
    }

    void Update()
    {

        
        disappearAnimationTimer -= Time.deltaTime;
        if(disappearAnimationTimer <= 4f && anim == false){
            disappearAnim.Play("seekerDisappear");
            anim = true;
        }
    }

    IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        gameObject.SetActive(false);
    }
}
