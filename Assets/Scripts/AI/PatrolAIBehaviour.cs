using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public struct AIState
{
    public bool Alert;
    public bool Searching;
}

[RequireComponent(typeof(NavMeshAgent))]
public class PatrolAIBehaviour : MonoBehaviour
{
    public Vector3[] Waypoints;
    public GameObject TargetPrefab;

    public bool Loop;
    GameObject target;

    private NavMeshAgent agent;
    private int current = 0;
    private float walkSpeed;

    private AIState state;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        walkSpeed = agent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(state.Alert && !state.Searching) StartCoroutine("Search");
        if(!state.Alert && !agent.pathPending && agent.remainingDistance < 0.5f) GotoNextPoint();
        if(state.Alert) agent.speed  = walkSpeed * 2f;
        else agent.speed = walkSpeed;
    }

    void GotoNextPoint()
    {
        if(Waypoints.Length == 0 || current == Waypoints.Length) return;
        
        agent.SetDestination(Waypoints[current++]);

        if(Loop && current == Waypoints.Length) current = 0;
    }

    public void Spotted(GameObject target)
    {
        if(this.target) Destroy(this.target);
        this.target = Instantiate(TargetPrefab, target.transform.position, target.transform.rotation);
        agent.SetDestination(this.target.transform.position);
        state.Alert = true;
    }

    IEnumerator Search()
    {
        state.Searching = true;
        yield return new WaitForSeconds(5f);
        Destroy(target);
        state.Searching = false;
        state.Alert = false;
        GotoNextPoint();
    }
}
