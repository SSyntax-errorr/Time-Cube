using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    private int randomSpawnPointIndex;
    [SerializeField]private Animator spawnObjective;
    private AudioSource objectiveSpawnSFX;
    //[SerializeField] private LayerMask playerLayer;

    void Start()
    {
        objectiveSpawnSFX = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 7){
            MoveObjective();
        }
    }
    void MoveObjective()
    {
            int indexCheck;
            do
            {
                indexCheck = Random.Range(0, spawnPoints.Count);
                
            } while (indexCheck == randomSpawnPointIndex);
            
        
            randomSpawnPointIndex = indexCheck;
            Transform spawnPoint = spawnPoints[randomSpawnPointIndex];
            gameObject.transform.position = spawnPoint.position;
            spawnObjective.SetTrigger("spawn");
            GameController.objectiveReached = true;
            objectiveSpawnSFX.Play();
            
            
    }
}
