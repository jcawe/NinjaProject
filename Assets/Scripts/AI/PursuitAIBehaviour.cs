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
    public float SearchTime;

    NavMeshAgent agent;
    bool searching;
    GameObject target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Spotted(GameObject target)
    {
        if(this.target) Destroy(this.target);
        this.target = Instantiate(TargetPrefab, target.transform.position, target.transform.rotation);
        agent.SetDestination(this.target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(target && !searching 
            && agent.remainingDistance <= agent.stoppingDistance) StartCoroutine(Search());
    }

    IEnumerator Search()
    {
        searching = true;
        yield return new WaitForSeconds(SearchTime);
        Destroy(target);
        searching = false;
        OnTargetLost?.Invoke();
    }
}