using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class AIAnimator : MonoBehaviour
{
    public float MaxSpeed;
    private NavMeshAgent agent;
    private Animator anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        var speed = agent.velocity.magnitude / MaxSpeed;

        anim.SetFloat("Forward", speed, .1f, Time.deltaTime);
    }
}
