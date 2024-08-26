using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{

    public static bool lifeLost;
    public Animator liveCountAnim;
    // Start is called before the first frame update
    void Start()
    {
        lifeLost = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeLost){
            liveCountAnim.Play("LivesCount");
            lifeLost = false;
        }
        
    }
}
