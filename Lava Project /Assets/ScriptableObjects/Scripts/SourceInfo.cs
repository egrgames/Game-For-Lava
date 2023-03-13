using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SourceInfo", menuName = "GameDesignerSettings/New SourceInfo")]
public class SourceInfo : ScriptableObject
{
    public int _numberOfFallResources = 1;
    public float TimeToRegenerateInSec = 1f;
    public float powerOfImpuls = 1f;
    public int NumberOfHitToZeroHealth = 5;

}
