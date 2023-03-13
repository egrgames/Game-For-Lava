using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "GameDesignerSettings/New PlayerInfo")]
public class PlayerInfo : ScriptableObject
{
    //радиус подбора ресурсов
    public float RadiusForCllectingObjects = 1.85f;

}
