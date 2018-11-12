using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveBehaviour : MonoBehaviour
{
    private Rigidbody RBody;

    public MoveConfiguration Move;

    void Start()
    {
        RBody = GetComponent<Rigidbody>();
    }

    public void ApplyMove(float direction)
    {
        RBody.velocity = transform.forward * Move.Speed * direction;
    }
}
