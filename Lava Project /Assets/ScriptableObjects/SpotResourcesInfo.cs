using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpotResourcesInfo", menuName = "GameDesignerSettings/New SpotResourcesInfo")]
public class SpotResourcesInfo : ScriptableObject
{
    //разброс ресурсов
    public float _spreadOfTheResources = 3f;

    //первый (большой) перерыв между летящими в спот ресурсами
    public float _slowDelay = 0.3f;
    //второй (короткий) перерыв между летящими в спот ресурсами
    public float _fastDelay = 0.14f;

    //необходимое кол-во ресурсов для конверсии
    public float _needeNumberOfRawRes = 10f;
    //кол-во ресурсов, которые можно получить
    public float _toRecieveThisNumberOfReady = 5f;

}
