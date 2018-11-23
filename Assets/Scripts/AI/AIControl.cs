using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIControl : MonoBehaviour
{
    public AxisEvent OnAxis;
    public ButtonEvent OnRun;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        // * We only want the NavMeshAgent as a guide
        agent.updateRotation = false;
        agent.updatePosition = false;
    }

    public void Run(bool run) => OnRun?.Invoke(run);

    void Update()
    {
        OnAxis?.Invoke(
            agent.remainingDistance > agent.stoppingDistance
                ? agent.desiredVelocity 
                : Vector3.zero
        );

        // * In order to make sure that agent follows the gameobject,
        // * we updates the navmeshposition to align with it.
        agent.nextPosition = transform.position;
    }
}
