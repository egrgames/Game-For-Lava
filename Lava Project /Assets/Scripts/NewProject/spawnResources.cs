using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnResources : MonoBehaviour
{
    public GameObject resource;
    public int forceUp = 5;
    public int forceX = 4;
    public int forceZ = 3;

    private float powerOfImpuls;

    public SourceInfo sourceInfo;
    private int NumberOfSpawnResources;
    // Start is called before the first frame update
    void Start()
    {
        powerOfImpuls = sourceInfo.powerOfImpuls;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnResource()
    {
        NumberOfSpawnResources = sourceInfo._numberOfFallResources;
        while(NumberOfSpawnResources > 0)
        {
        forceUp = Random.Range(3, 5);
        forceX = Random.Range(-3, 3);
        forceZ = Random.Range(-5, -3);
        /*float xAngle = Random.Range(-180f, 0f);
        float yAngle = Random.Range(-180f, 180f);
        float zAngle = Random.Range(-180f, 180f);
        Vector3 ang = new Vector3(xAngle, yAngle, zAngle);*/
        GameObject resourceExisted = Instantiate(resource, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Quaternion.identity);
        resourceExisted.GetComponent<Rigidbody>().AddForce(powerOfImpuls * forceX, powerOfImpuls * forceUp, powerOfImpuls * forceZ, ForceMode.Impulse);
        NumberOfSpawnResources -= 1;
        }

    }
    public void SpawnResourceFromSpot()
    {
        forceUp = Random.Range(3, 5);
        forceX = Random.Range(-3, 3);
        forceZ = Random.Range(-3, -2);
        GameObject resourceExisted = Instantiate(resource, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Quaternion.identity);
        resourceExisted.GetComponent<Rigidbody>().AddForce(forceX, forceUp, forceZ, ForceMode.Impulse);
    }
}
