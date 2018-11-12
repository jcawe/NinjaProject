using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{
    public MoveConfiguration Move;
    public Rigidbody RBody;
    
    public void ApplyMove(float direction)
    {
        RBody.AddForce(Vector3.forward * direction * Move.Speed);
    }
}
