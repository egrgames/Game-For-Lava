using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resourceScript : MonoBehaviour
{
    public bool isGrababble = false;
    private float timeToGrab = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeToGrab += 1f;
        if(timeToGrab >= 50f)
        {
            isGrababble = true;
        }
    }
}
