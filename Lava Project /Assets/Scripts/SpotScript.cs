using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpotScript : MonoBehaviour
{
    public float RawResource;
    public float ReadyResource;

    public float NeededRawNum = 10;
    public float ToRecieveThisNumberOfReady = 5;
    public float timeToRecieveRededResources = 10f;
    private float periodOfTimeBetweenSpawn;
    private int numberOfSpawnedResources;

    public bool isItReadyToStartCooking;

    public Text RawNumText;
    public Text ReadyNumText;

    public ParticleSystem Smoke;

    public SpotResourcesInfo spotInfo;


    void Start()
    {
        NeededRawNum = spotInfo._needeNumberOfRawRes;
        ToRecieveThisNumberOfReady = spotInfo._toRecieveThisNumberOfReady;
    }

    void FixedUpdate()
    {
        RawNumText.text = RawResource.ToString();
        ReadyNumText.text = ReadyResource.ToString();
        if(RawResource == NeededRawNum && isItReadyToStartCooking == false)
        {
            isItReadyToStartCooking = true;
            ReadyResource = ToRecieveThisNumberOfReady;
            StartCooking();
            Smoke.Play();
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if((collision.gameObject.name == "WoodPile(Clone)" || collision.gameObject.name == "MetalResource(Clone)") && RawResource < NeededRawNum && isItReadyToStartCooking == false)
        {
            Destroy(collision.gameObject);
            RawResource += 1;
        }
    }

    private void StartCooking()
    {
        if(numberOfSpawnedResources < ToRecieveThisNumberOfReady)
        {
            periodOfTimeBetweenSpawn = timeToRecieveRededResources / ToRecieveThisNumberOfReady;
            Invoke("spawnReadyResource", periodOfTimeBetweenSpawn);
        }
        else
        {
            isItReadyToStartCooking = false;
            numberOfSpawnedResources = 0;
            RawResource = 0;
            Smoke.Stop();
        }
    }
    private void spawnReadyResource()
    {
        gameObject.GetComponent<spawnResources>().SpawnResourceFromSpot();
        numberOfSpawnedResources += 1;
        ReadyResource = ToRecieveThisNumberOfReady - numberOfSpawnedResources;
        RawResource = RawResource - (NeededRawNum/ToRecieveThisNumberOfReady);
        StartCooking();
    }
}
