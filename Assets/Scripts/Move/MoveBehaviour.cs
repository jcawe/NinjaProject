using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class MoveBehaviour : MonoBehaviour
{
    public MoveConfiguration MoveProfile;
    public string MoveParameter = "Forward";
    public string TurnParameter = "Turn";
    
    private Animator anim;
    private Rigidbody rb;
    private float hAxis;
    private float vAxis;
    private bool run;
    private bool sneak;

    public float angleSpeed;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    
    public void Run(bool run) => this.run = run;
    public void Sneak(bool sneak) => this.sneak = sneak;

    public void Horizontal(float axis) => hAxis = axis;
    public void Vertical(float axis) => vAxis = axis;

    void FixedUpdate()
    {
        var dir = new Vector3(hAxis, 0f, vAxis);
        var angle = Vector3.SignedAngle(transform.forward, dir, Vector3.up)/180f;
        var speed = dir.magnitude * (run ? 1f : 0.5f);

        anim.SetFloat(TurnParameter, angle * angleSpeed, .1f, Time.deltaTime);
        anim.SetFloat(MoveParameter, speed, .1f, Time.deltaTime);
    }
}
