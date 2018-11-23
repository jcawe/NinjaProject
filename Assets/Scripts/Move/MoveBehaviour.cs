using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MoveBehaviour : MonoBehaviour
{
    public MoveConfiguration Profile;

    private Animator anim;
    private bool isRunning;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Run(bool run) => isRunning = run;
    public void Move(Vector3 move)
    {
        move = transform.InverseTransformDirection(move.magnitude > 1 ? move.normalized : move);

        var turn = Mathf.Atan2(move.x, move.z);
        var speed = Mathf.Clamp(
            move.z * Profile.MaxSpeed, 
            0f, 
            isRunning ? Profile.MaxSpeed : .5f
        );

        float turnSpeed = Mathf.Lerp(
            Profile.StationaryTurnSpeed, 
            Profile.MovementTurnSpeed, 
            speed
        );
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);


        anim.SetFloat("Turn", turn, .1f, Time.deltaTime);
        anim.SetFloat("Forward", speed, .1f, Time.deltaTime);
    }
}
