using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class PursuitAIBehaviour : MonoBehaviour
{
    NavMeshAgent agent;
    bool searching;
    GameObject target;
    public GameObject TargetPrefab;

    public float RunMultiplier;
    public UnityEvent OnTargetLost;
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
        if(target && !searching && !agent.hasPath) StartCoroutine("Search");
    }

    IEnumerator Search()
    {
        searching = true;
        yield return new WaitForSeconds(5f);
        Destroy(target);
        searching = false;
        agent.speed = walkSpeed;
        OnTargetLost?.Invoke();
    }
}