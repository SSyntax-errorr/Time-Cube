using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRecorder : MonoBehaviour
{
    public List<Vector2> recordedMovements;
    public List<Vector3> recordedPositions;
    public static bool pause;
    
    void Start()
    {
        pause = false;
        recordedMovements = new List<Vector2>();
        recordedPositions = new List<Vector3>();
    }

    void Update()
    {
        if(pause) return;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        recordedMovements.Add(movement);
        
        Vector3 position = transform.position;
        recordedPositions.Add(position);
    }
}
