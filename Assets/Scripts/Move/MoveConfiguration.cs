using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Move", menuName="NinjaProject/Move")]
public class MoveConfiguration : ScriptableObject
{
    public float Speed;

    public Rigidbody RBody;
}
