using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    
    public static bool playerPause;

    [SerializeField] protected AudioSource damageSFX;

    [SerializeField] private Animator lives;
    [SerializeField] private GameObject livesText;

    protected Collider2D playerCollider;
    
    float colliderTimer;
    public static bool colliderCooldown;
    [SerializeField] private  float inputColliderTimer;
    
   
   void Start()
   {
        playerPause = false;
        damageSFX = GetComponent<AudioSource>();
        playerCollider = GetComponent<Collider2D>();
        colliderTimer = inputColliderTimer;
        colliderCooldown = false;
   }

    void Update()
    {   
        if(playerPause){
            return;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * moveSpeed;

        transform.Translate(movement * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space)){
            
        }

      if(colliderCooldown && colliderTimer > 0){
        colliderTimer -= Time.deltaTime;

      } else if(colliderCooldown && colliderTimer <= 0){
            colliderCooldown = false;
      }
    }

    protected void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.gameObject.layer == 9  && !colliderCooldown){
            colliderTimer = inputColliderTimer;
            colliderCooldown = true;
            damageSFX.Play();
            Lives.lifeLost = true;
            //colliderTimer = 0.3f;
            
        }


        
    }


}
