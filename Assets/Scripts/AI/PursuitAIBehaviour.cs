using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class PursuitAIBehaviour : MonoBehaviour
{
    public UnityEvent OnTargetLost;
    public GameObject TargetPrefab;
    public float RunMultiplier;
    public float SearchTime;

    NavMeshAgent agent;
    bool searching;
    GameObject target;
    float walkSpeed;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        walkSpeed = agent.speed;
    }

    public void Spotted(GameObject target)
    {
        if(this.target) Destroy(this.target);
        this.target = Instantiate(TargetPrefab, target.transform.position, target.transform.rotation);
        agent.SetDestination(this.target.transform.position);
        agent.speed = walkSpeed * RunMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if(target && !searching && !agent.hasPath) StartCoroutine(Search());
    }

    IEnumerator Search()
    {
        searching = true;
        yield return new WaitForSeconds(SearchTime);
        Destroy(target);
        searching = false;
        agent.speed = walkSpeed;
        OnTargetLost?.Invoke();
    }
}