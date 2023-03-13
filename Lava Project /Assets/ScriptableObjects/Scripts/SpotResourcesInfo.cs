using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpotResourcesInfo", menuName = "GameDesignerSettings/New SpotResourcesInfo")]
public class SpotResourcesInfo : ScriptableObject
{
    public float _spreadOfTheResources = 3f;
    public float _slowDelay = 0.3f;
    public float _fastDelay = 0.14f;
    public float _needeNumberOfRawRes = 10f;
    public float _toRecieveThisNumberOfReady = 5f;

}
