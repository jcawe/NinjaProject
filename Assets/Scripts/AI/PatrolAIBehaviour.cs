using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public struct AIState
{
    public bool Alert;
    public bool Searching;
    public bool Peeing;
}

[RequireComponent(typeof(NavMeshAgent))]
public class PatrolAIBehaviour : MonoBehaviour
{
    public Vector3[] Waypoints;

    public bool Loop;

    private NavMeshAgent agent;
    private int current = 0;

    private AIState state;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!agent.pathPending && agent.remainingDistance < 0.5f) GotoNextPoint();
    }

    void GotoNextPoint()
    {
        if(Waypoints.Length == 0 || current == Waypoints.Length) return;
        
        agent.SetDestination(Waypoints[current++]);

        if(Loop && current == Waypoints.Length) current = 0;
    }
}
