using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "NinjaProject/Move")]
public class MoveConfiguration : ScriptableObject
{
    [Range(0f, 1f)]
    public float MaxSpeed;

    [Range(0f, 360f)]
    public float StationaryTurnSpeed;

    [Range(0f, 360f)]
    public float MovementTurnSpeed;
}
