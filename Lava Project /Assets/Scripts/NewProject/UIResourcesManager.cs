using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIResourcesManager : MonoBehaviour
{
    public GameObject Player;

    public GameObject woodResIndicator;
    public GameObject metalResIndicator;
    public GameObject crystalResIndicator;

    public Transform FirstPosition;
    public Transform SecondPosition;
    public Transform ThirdPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Player.GetComponent<PlayerResourcesScript>().woodRes > 0)
        {
            woodResIndicator.SetActive(true);
            if (Player.GetComponent<PlayerResourcesScript>().metalRes > 0)
            {
                metalResIndicator.SetActive(true);
                if (Player.GetComponent<PlayerResourcesScript>().cristallRes > 0)
                {
                    crystalResIndicator.SetActive(true);
                    woodResIndicator.transform.position = new Vector3(FirstPosition.position.x, FirstPosition.position.y, FirstPosition.position.z);
                metalResIndicator.transform.position = new Vector3(SecondPosition.position.x, SecondPosition.position.y, SecondPosition.position.z);
                crystalResIndicator.transform.position = new Vector3(ThirdPosition.position.x, ThirdPosition.position.y, ThirdPosition.position.z);
                }
                else
                {
                    woodResIndicator.transform.position = new Vector3(FirstPosition.position.x, FirstPosition.position.y, FirstPosition.position.z);
                    metalResIndicator.transform.position = new Vector3(SecondPosition.position.x, SecondPosition.position.y, SecondPosition.position.z);
                    crystalResIndicator.SetActive(false);
                }
            }
            else
            {
                if (Player.GetComponent<PlayerResourcesScript>().cristallRes > 0)
                {
                    crystalResIndicator.SetActive(true);
                    woodResIndicator.transform.position = new Vector3(FirstPosition.position.x, FirstPosition.position.y, FirstPosition.position.z);
                    crystalResIndicator.transform.position = new Vector3(SecondPosition.position.x, SecondPosition.position.y, SecondPosition.position.z);
                    metalResIndicator.SetActive(false);
                }
                else
                {
                    woodResIndicator.transform.position = new Vector3(FirstPosition.position.x, FirstPosition.position.y, FirstPosition.position.z);
                    metalResIndicator.SetActive(false);
                    crystalResIndicator.SetActive(false);
                }
            }
        }
        else
        {
            if (Player.GetComponent<PlayerResourcesScript>().metalRes > 0)
            {
                metalResIndicator.SetActive(true);
                if (Player.GetComponent<PlayerResourcesScript>().cristallRes > 0)
                {
                    crystalResIndicator.SetActive(true);
                    woodResIndicator.SetActive(false);
                    metalResIndicator.transform.position = new Vector3(FirstPosition.position.x, FirstPosition.position.y, FirstPosition.position.z);
                    crystalResIndicator.transform.position = new Vector3(SecondPosition.position.x, SecondPosition.position.y, SecondPosition.position.z);
                }
                else
                {
                    woodResIndicator.SetActive(false);
                    metalResIndicator.transform.position = new Vector3(FirstPosition.position.x, FirstPosition.position.y, FirstPosition.position.z);
                    crystalResIndicator.SetActive(false);
                }
            }
            else
            {
                if (Player.GetComponent<PlayerResourcesScript>().cristallRes > 0)
                {
                    crystalResIndicator.SetActive(true);
                    woodResIndicator.SetActive(false);
                    crystalResIndicator.transform.position = new Vector3(FirstPosition.position.x, FirstPosition.position.y, FirstPosition.position.z);
                    metalResIndicator.SetActive(false);
                }
                else
                {
                    woodResIndicator.SetActive(false);
                    metalResIndicator.SetActive(false);
                    crystalResIndicator.SetActive(false);
                }
            }
        }
    }
}
