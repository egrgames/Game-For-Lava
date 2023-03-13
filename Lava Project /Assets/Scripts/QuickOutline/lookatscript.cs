using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatscript : MonoBehaviour
{
    public Transform CamObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(CamObj);
        //transform.LookAt(target);
    }
    /*void OnCollisionEnter(Collision collision)
    {   
        if(collision.gameObject.name == "Market")
        {
            CamObj.transform.LookAt(collision.gameObject.transform);
        }
    }*/


}
