using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SourceInfo", menuName = "GameDesignerSettings/New SourceInfo")]
public class SourceInfo : ScriptableObject
{
    //количество выпадающих ресурсов
    public int _numberOfFallResources = 1;

    //время до полного восстановления источника
    public float TimeToRegenerateInSec = 1f;

    //настраиваем силу импульса
    public float powerOfImpuls = 1f;

    //количество ударов до истощения источника
    public int NumberOfHitToZeroHealth = 5;

}
